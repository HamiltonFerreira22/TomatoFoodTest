namespace TomatoFoodTest.Steps
{
    //notação utilizada para os testes de features
    [Binding]
    public class RegisterSteps
    {
        RegisterServices response = new RegisterServices();
        RegisterResponse resposta;

        public string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");

        public string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;

        public string funcaoGerente = "manager";

        [Given(@"que preciso gerar um usuario gerente")]
        public void DadoQuePrecisoGerarUmUsuarioGerente()
        {
            var faker = new Faker("pt_BR");
            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();    

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;
        }

        [When(@"requisito a API de Registro com nome, email, senha, confirmacao da senha e funcao")]
        public void QuandoRequisitoAAPIDeRegistroComNomeEmailSenhaConfirmacaoDaSenhaEFuncao()
        {         
             resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);   
        }

        [Then(@"deve cadastrar com sucesso")]
        public void EntaoDeveCadastrarComSucesso()
        {
            Assert.AreEqual(funcaoGerente, resposta.role);
            Assert.AreEqual(nomeCadastro, resposta.name);
            Assert.IsNotNull(resposta.password);
            Assert.AreEqual(0, resposta.__v);
            Assert.IsNotNull(resposta._id);
            Assert.AreEqual(emailCadastro, resposta.email);
            Assert.AreEqual(dataAtual, resposta.date.Substring(0, 10));
            Assert.AreEqual(200, (int)response.resp.StatusCode);
        }

    }
}
