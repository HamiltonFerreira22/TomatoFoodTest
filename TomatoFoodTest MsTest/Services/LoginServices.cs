
namespace TomatoFoodTest.Services
{
    public  class LoginServices : BaseService
    {        
        public void bodyLogin(LoginRequest login)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(login);
        }
        public LoginResponse FazerLogin(string email, string senha)
        {
            Client(urlBase);
            Endpoint("users/login");
            Post();
            bodyLogin(new LoginRequest
            {
                email = email,
                password = senha,
            });
            ExecutaRequest();
            RetornaResposta("Resposta API de Login");

            var response = JsonConvert.DeserializeObject<LoginResponse>(resp.Content);

            return response;
        }
    }   
}
