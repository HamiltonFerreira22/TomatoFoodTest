
namespace TomatoFoodTest.Services
{
    public class OrdersServices : BaseService
    {     
        public void bodyOrders(object orders)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(orders);
        }
        public OrdersResponse CriarOrderm(double total, string idRefeicao, string idRestaurant, string token)
        {
            Client(urlBase);
            Endpoint("orders");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Post();
            bodyOrders(new OrdersRequest
            {
                total_amount = total,
                _meals = new ArrayList() { idRefeicao },
                _restaurant = idRestaurant
            });
            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido ");

            if (resp.ContentType.Contains(MediaTypeNames.Application.Json))
            {
                var response = JsonConvert.DeserializeObject<OrdersResponse>(resp.Content);

                return response;
            }
            else
            {
                return new OrdersResponse() { message = ($"{(int)resp.StatusCode}-{resp.StatusDescription}") };
            }
        }
        public OrdersResponse AlterarStatusOrderm(string token, string status ,string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Put();
            bodyOrders(new 
            {
                status = status
            });
            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - PUT");

            if (resp.ContentType.Contains(MediaTypeNames.Application.Json))
            {
                var response = JsonConvert.DeserializeObject<OrdersResponse>(resp.Content);

                return response;
            }
            else
            {
                return new OrdersResponse() { message = ($"{(int)resp.StatusCode}-{resp.StatusDescription}") };
            }
        }
        public void DeletaOrderm(string token, string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Delete();
            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - DELETED");

            Console.WriteLine($"Pedido {idPedido} foi deletado!!!");
        }
        public void BuscarOrderm(string token, string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Get();
            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - GET");

            Console.WriteLine($"Pedido {idPedido} encontrado!!!");
        }
    }
}
