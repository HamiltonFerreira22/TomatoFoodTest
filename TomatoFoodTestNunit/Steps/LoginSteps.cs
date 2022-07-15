

namespace TomatoFoodTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        public string senhaCadastro;
        LoginServices responseLS = new LoginServices();
        LoginResponse response;

        [Given(@"que preciso de uma senha invalida")]
        public void DadoQuePrecisoDeUmaSenhaInvalida()
        {
            var faker = new Faker("pt_BR");
            var senhaFaker = faker.Internet.Password();
            senhaCadastro = senhaFaker;
        }

        [When(@"requisito a API de login com email e senha '(.*)'")]
        public void QuandoRequisitoAAPIDeLoginComEmailESenha(string email)
        {  
             response = responseLS.FazerLogin(email, senhaCadastro);
        }

        [Then(@"deve ver mostrar mensagem '(.*)'")]
        public void EntaoDeveVerMostrarMensagem(string msg)
        {
            Assert.AreEqual(msg, response.passwordincorrect);
            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

    }
}
