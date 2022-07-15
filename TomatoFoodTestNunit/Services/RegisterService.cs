
namespace TomatoFoodTest.Services
{
    public class RegisterServices : BaseService
    { 
        public void bodyRegister(RegisterRequest registro)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(registro);
        }
        public RegisterResponse CadastrarConta(string nome, string email, string senha1, string senha2, string funcao)
        {
            Client(urlBase);
            Endpoint("users/register");
            Post();
            bodyRegister(new RegisterRequest
            {
                email = email,
                name = nome,
                password = senha1,
                password2 = senha2,
                role = funcao
            });
            ExecutaRequest();
            RetornaResposta("Resposta API de Registro");

            var response = JsonConvert.DeserializeObject<RegisterResponse>(resp.Content);

            return response;
        }
    }
}
