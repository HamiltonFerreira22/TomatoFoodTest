
namespace TomatoFoodTest.Steps
{
    [Binding]
    public class RestaurantSteps
    {
        RestaurantServices responseRS = new RestaurantServices();
        RestaurantResponse response;
        public static string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
        public static string funcaoGerente = "manager";

        public static string tkn;

        //Para que ele faça os passos antes do teste uma vez utiliza Before no SpecFlow
        [Before]
        public static void DeveRealizarCadastroDeConta()
        {
            var faker = new Faker("pt_BR");
            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;

            //metodo para fazer o registro de um usuario
            RegisterServices responseRS = new RegisterServices();
            responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);           
        }


        [Given(@"que tenho perfil de gerente")]
        public void DadoQueTenhoPerfilDeGerente()
        {
            //metodo para fazer o login com esse usuario 
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin(emailCadastro, senhaCadastro);

            tkn = response.token;
        }

        [When(@"envio o cadastro com restaurante, descricao, tipo e refeicao '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void QuandoEnvioOCadastroComRestauranteDescricaoTipoERefeicao(string nome_restaurante, string tipo_restaurante, string descricao_restaurante, string refeicao, string DescRefe, string preco)
        {         
            response = responseRS.CadastrarRestaurante(nome_restaurante, tipo_restaurante, descricao_restaurante, refeicao, DescRefe, preco, tkn);
            Assert.AreEqual(nome_restaurante, response.name);
            Assert.AreEqual(tipo_restaurante, response.type);
            Assert.AreEqual(descricao_restaurante, response.description);
        }

        [Then(@"deve cadastrar com sucesso o restaurante")]
        public void EntaoDeveCadastrarComSucessoORestaurante()
        {
            Assert.IsNotNull(response._id);
            Assert.AreEqual(0, response.__v);
            Assert.IsNotNull(response._meals);
            Assert.AreEqual(201, (int)responseRS.resp.StatusCode);
        }

    }
}
