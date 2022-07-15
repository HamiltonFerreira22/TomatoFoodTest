namespace TomatoFoodTest.Tests
{
    [TestClass]
    public class LoginTest
    {
        public string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
        public string funcaoGerente = "manager";
        public string funcaoUsuario = "user";

        [TestInitialize]
        public void DeveRealizarCadastroDeConta()
        {
            var faker = new Faker("pt_BR");
            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;

            RegisterServices responseRS = new RegisterServices();

            responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);
        }

        [TestMethod]
        public void T01DeveRealizarLoginComSucesso()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin(emailCadastro, senhaCadastro);
            Assert.IsNotNull(response.token);
            Assert.IsTrue(response.Success);

            Assert.AreEqual(200, (int)responseLS.resp.StatusCode);
        }

        [TestMethod]
        public void T02NaoDeveRealizarLoginComSenhaInvalida()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin(emailCadastro, "123456");

            Assert.AreEqual("Password incorrect", response.passwordincorrect);

            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

        [TestMethod]
        public void T03NaoDeveRealizarLoginComInformacoesVazias()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin("", "");

            Assert.AreEqual("Email field is required", response.email);

            Assert.AreEqual("Password field is required", response.password);

            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

        [TestMethod]
        public void T04NaoDeveRealizarLoginComEmailNaoCadastrado()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin("test@test.com", senhaCadastro);

            Assert.AreEqual("Email not found", response.emailnotfound);

            Assert.AreEqual(404, (int)responseLS.resp.StatusCode);
        }

        [TestMethod]
        public void T05NaoDeveRealizarLoginComEmailInvalido()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.FazerLogin("test@test", senhaCadastro);

            Assert.AreEqual("Email is invalid", response.email);

            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

        [TestMethod]
        public void T06DeveValidarContratoDaApiLogin()
        {
            LoginServices responseLS = new LoginServices();

            responseLS.FazerLogin(emailCadastro, senhaCadastro);

            JObject json = JObject.Parse(responseLS.resp.Content);

            //Validar se o json é verdadeiro baseado no contrato da api, caso não sejá vai retornar uma lista dos itens divergentes no response
            Assert.IsTrue(json.IsValid(LoginSchema.LoginJson(), out IList<string> messages), String.Join(",", messages));
        }
    }
}
