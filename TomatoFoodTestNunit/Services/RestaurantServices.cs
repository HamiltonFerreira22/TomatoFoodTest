
namespace TomatoFoodTest.Services
{
    public class RestaurantServices : BaseService
    {      
        public void bodyRestaurant(RestaurantRequest restaurant)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(restaurant);
        }
        public RestaurantResponse CadastrarRestaurante(string nomeRest, string tipoRest, string descRest, string nomeMeal, string descMeal, string precoMeal, string token )
        {
            Client(urlBase);
            Endpoint("/restaurants");
            Header("Authorization",token);
            Header("Content-Type", "application/json");
            Post();
            bodyRestaurant(new RestaurantRequest
            {
                name = nomeRest,
                type = tipoRest,
                description = descRest,
                _meals = new List<Meal>() { new Meal {name = nomeMeal, price = precoMeal, description = descMeal } }
            });
            ExecutaRequest();
            RetornaResposta("Resposta API de Restaurante");

            if(resp.ContentType.Contains(MediaTypeNames.Application.Json))
            {
                var response = JsonConvert.DeserializeObject<RestaurantResponse>(resp.Content);

                return response;
            }
            else
            {
                //verificar se vai quebrar aqui 
                return new RestaurantResponse() { message = ($"{(int)resp.StatusCode}-{resp.StatusDescription}") };
            }
        }
    }
}
