
namespace TomatoFoodTest.Steps
{
    [Binding]
    public class OrdersSteps
    {
        OrdersServices ordersServices = new OrdersServices();
        OrdersResponse responseOrder;
       
        public static string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
        public static string funcaoGerente = "manager";
        public static string tkn, idUsuario, idRestaurant, idRefeicao;
        public string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");

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
            var responseRegister = responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            //variavel de id de usuario
            idUsuario = responseRegister._id;

            //metodo para fazer o login com esse usuario 
            LoginServices responseLS = new LoginServices();
            var responseLogin = responseLS.FazerLogin(emailCadastro, senhaCadastro);
            //variavel do token
            tkn = responseLogin.token;            
        }

        [Given(@"que tenho acesso para realizar pedido")]
        public void DadoQueTenhoAcessoParaRealizarPedido()
        {
            //metodo para criar um restaurante
            RestaurantServices restaurantServices = new RestaurantServices();
            var responseRestaurante = restaurantServices.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);
            //variavel de id do restaurante
            idRestaurant = responseRestaurante._id;
            //variavel de id da refeicao colocar a posição do array
            idRefeicao = responseRestaurante._meals[0];
        }

        [When(@"envio a ordem com valor restaurante e refeicao")]
        public void QuandoEnvioAOrdemComValorRestauranteERefeicao()
        {            
            responseOrder = ordersServices.CriarOrderm(352.87, idRefeicao, idRestaurant, tkn);            
        }

        [Then(@"deve cadastrar o pedido com o desconto '(.*)'")]
        public void EntaoDeveCadastrarOPedidoComODesconto(double desc)
        {
            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(352.87, responseOrder.subtotal);           
            Assert.AreEqual(desc, responseOrder.total_discount);
            Assert.AreEqual(335.2265, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        //Validação dos pedidos
        [When(@"envio a ordem com valor restaurante e refeicao '(.*)'")]
        public void QuandoEnvioAOrdemComValorRestauranteERefeicao(double valor)
        {
            responseOrder = ordersServices.CriarOrderm(valor, idRefeicao, idRestaurant, tkn);
        }

        [Then(@"deve cadastrar os pedidos com os descontos '(.*)'")]
        public void EntaoDeveCadastrarOsPedidosComOsDescontos(double desc)
        {
           Assert.AreEqual(desc, responseOrder.total_discount);
        }
    }
}
