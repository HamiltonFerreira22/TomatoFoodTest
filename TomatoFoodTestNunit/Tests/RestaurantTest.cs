
namespace TomatoFoodTest.Tests
{
    
    public class RestaurantTest
    {
        public static string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
        public static string funcaoGerente = "manager";
        public string funcaoUsuario = "user";
        public static string tkn;

        [OneTimeSetUp]
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

            //metodo para fazer o login com esse usuario 
            LoginServices responseLS = new LoginServices();
            var response = responseLS.FazerLogin(emailCadastro, senhaCadastro);

            tkn = response.token;
        }

        [Test]
        public void DeveCadastrarComSucessoUmRestaurante()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);

            Assert.IsNotNull(response._id);
            Assert.AreEqual("TerraBrasil", response.name);
            Assert.AreEqual("Restaurante brasileiro", response.type);
            Assert.AreEqual("Comida brasileira", response.description);
            Assert.AreEqual(0, response.__v);
            Assert.IsNotNull(response._meals);
            Assert.AreEqual(201,(int) responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemNome()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);        

            Assert.AreEqual("Restaurant validation failed: name: Path `name` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemTipo()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);

            Assert.AreEqual("Restaurant validation failed: type: Path `type` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemDescricao()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "", "peixe", "peixe assado", "20.87", tkn);

            Assert.AreEqual("Restaurant validation failed: description: Path `description` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemNomeRefeicao()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "", "peixe assado", "20.87", tkn);

            Assert.AreEqual("Meal validation failed: name: Path `name` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemDescricaoRefeicao()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "", "20.87", tkn);

            Assert.AreEqual("Meal validation failed: description: Path `description` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarUmRestauranteSemPreco()
        {
            RestaurantServices responseRS = new RestaurantServices();

            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "", tkn);

            Assert.AreEqual("Meal validation failed: price: Path `price` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveCadastrarRestauranteComUsuarioUser()
        {

            //metodo para fazer o registro de um usuario
            RegisterServices responseRS = new RegisterServices();
            responseRS.CadastrarConta(nomeCadastro, "user"+emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            //metodo para fazer o login com esse usuario 
            LoginServices responseLS = new LoginServices();
            var responseLogin = responseLS.FazerLogin("user"+emailCadastro, senhaCadastro);

            RestaurantServices responseRSS = new RestaurantServices();

             var response = responseRSS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", responseLogin.token);

            Assert.AreEqual("Forbidden",response.message );
        }

        [Test]
        public void T06DeveValidarContratoDaApiRestaurant()
        {
            RestaurantServices responseRS = new RestaurantServices();
             responseRS.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);

            JObject json = JObject.Parse(responseRS.resp.Content);

            //Validar se o json é verdadeiro baseado no contrato da api, caso não sejá vai retornar uma lista dos itens divergentes no response
            Assert.IsTrue(json.IsValid(RestaurantSchema.RestaurantJson(), out IList<string> messages), String.Join(",", messages));
        }
    }
}
