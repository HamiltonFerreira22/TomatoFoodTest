
namespace TomatoFoodTest.Tests
{
    [TestClass]
    public class RegisterTest
    {
        //public string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");
        // por causa do horario utc do meu server mudei isso 
        public string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");

        public string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;

        public string funcaoGerente = "manager";

        public string funcaoUsuario = "user";
       

        [TestInitialize]
        // É necesssario que ele rode antes de todos os testes por isso o metodo TestInitialize foi implementado
        public void GerarDadosTeste()
        {
            var faker = new Faker("pt_BR");
            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();
            var telefoneFaker = faker.Phone.PhoneNumber();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;
            telefoneCadastro = telefoneFaker;
        }
        [TestMethod]
        public void DeveCadastrarUsuarioComFuncaoGerente()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            Assert.AreEqual(funcaoGerente, resposta.role);
            Assert.AreEqual(nomeCadastro, resposta.name);
            Assert.IsNotNull(resposta.password);
            Assert.AreEqual(0, resposta.__v);
            Assert.IsNotNull(resposta._id);
            Assert.AreEqual(emailCadastro, resposta.email);
            Assert.AreEqual(dataAtual, resposta.date.Substring(0, 10));
            Assert.AreEqual(200,(int)response.resp.StatusCode);         
        }

        [TestMethod]
        public void DeveCadastrarUsuarioComFuncaoUsuario()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual(funcaoUsuario, resposta.role);
            Assert.AreEqual(nomeCadastro, resposta.name);
            Assert.IsNotNull(resposta.password);
            Assert.AreEqual(0, resposta.__v);
            Assert.IsNotNull(resposta._id);
            Assert.AreEqual(emailCadastro, resposta.email);
            Assert.AreEqual(dataAtual, resposta.date.Substring(0, 10));
            Assert.AreEqual(200, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComNomeVazio()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta("", emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Name field is required", resposta.name);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComEmailVazio()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, "", senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Email field is required", resposta.email);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComEmailInvalido()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, "abc@abc", senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Email is invalid", resposta.email);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComSenhaVazia()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, "", senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Password must be at least 6 characters", resposta.password);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComSenhasDiferentes()
        {
            RegisterServices response = new RegisterServices();

            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, "123456", funcaoUsuario);

            Assert.AreEqual("Passwords must match", resposta.password2);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void DeveValidarContratoDaApiRegister()
        {
            RegisterServices response = new RegisterServices();

            response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            JObject json = JObject.Parse(response.resp.Content);

            //Validar se o json é verdadeiro baseado no contrato da api, caso não sejá vai retornar uma lista dos itens divergentes no response
            Assert.IsTrue(json.IsValid(RegisterSchema.RegisterJson(),out IList<string> messages), String.Join(",",messages));
        }
    }
}
