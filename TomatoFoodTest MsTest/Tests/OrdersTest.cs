
namespace TomatoFoodTest.Tests
{
    [TestClass]
    public  class OrdersTest
    {
        public string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");
        public static string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
        public static string funcaoGerente = "manager";
        public string funcaoUsuario = "user";
        public static string tkn, idUsuario, idRestaurant, idRefeicao;

        [ClassInitialize()]
        public static void DeveRealizarCadastroDeConta(TestContext testContext)
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

            //metodo para criar um restaurante
            RestaurantServices restaurantServices = new RestaurantServices();
            var responseRestaurante = restaurantServices.CadastrarRestaurante("TerraBrasil", "Restaurante brasileiro", "Comida brasileira", "peixe", "peixe assado", "20.87", tkn);

            //variavel de id do restaurante
            idRestaurant = responseRestaurante._id;
            //variavel de id da refeicao colocar a posição do array
            idRefeicao = responseRestaurante._meals[0];
        }

        [TestMethod]
        public void T01DeveCriarComSucessoUmpedido()
        {
           OrdersServices ordersServices = new OrdersServices();
           var responseOrder = ordersServices.CriarOrderm(352.87,idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(352.87, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(335.2265, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0,10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }


        [TestMethod]
        public void T02DeveValidarParticaoUm()
        {   // testes de particao de equivalencia em 4 partes
            //teste deve validar um pedido menor que R$ 250,00 sem desconto
            //verificar se consigo usar test categori
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(122.40, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(122.40, responseOrder.subtotal);
            Assert.AreEqual(0.00, responseOrder.total_discount);
            Assert.AreEqual(122.40, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201,(int) ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T03DeveValidarParticaoDois()
        {
            //teste deve validar um pedido maior de R$ 250,00 com 5% de desconto   
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(324.50, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(324.50, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(308.275, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T04DeveValidarParticaoTres()
        {
            //teste deve validar um pedido maior que R$ 500,00 com 8% de desconto   
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(654.98, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(654.98, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(602.5816, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T05DeveValidarParticaoQuatro()
        {
            //teste deve validar um pedido maior que R$ 700,00 com 10% de desconto   
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(1196.77, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(1196.77, responseOrder.subtotal);
            Assert.AreEqual(0.10, responseOrder.total_discount);
            Assert.AreEqual(1077.093, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T06DeveValidarLimiteInferiorDe250()
        {
            //teste de limites inferior e superior  
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(249.99, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(249.99, responseOrder.subtotal);
            Assert.AreEqual(0.00, responseOrder.total_discount);
            Assert.AreEqual(249.99, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T07DeveValidarLimiteSuperiorDe250()
        {
             
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(250.01, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(250.01, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(237.5095, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T08DeveValidarLimiteInferiorDe500()
        {
            //teste de limites inferior e superior  
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(499.99, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(499.99, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(474.9905, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T09DeveValidarLimiteSuperiorDe500()
        {

            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(500.01, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(500.01, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(460.00919999999996, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T10DeveValidarLimiteInferiorDe700()
        {
            //teste de limites inferior e superior  
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(699.99, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(699.99, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(643.9908, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T11DeveValidarLimiteSuperiorDe700()
        {

            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(700.01, responseOrder.subtotal);
            Assert.AreEqual(0.10, responseOrder.total_discount);
            Assert.AreEqual(630,009, responseOrder.total_amount);
            Assert.AreEqual(idRestaurant, responseOrder._restaurant);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }


        //tecnica de transiçao de estados
        //verifica os possiveis estados que a aplicaçao pode ter 
        [TestMethod]
        public void T12DeveValidarTransicaoDeTodosStatusCorretamente()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            //alterar status
            var orderProcessing =  ordersServices.AlterarStatusOrderm(tkn, "processing", responseOrder._id);
            Assert.AreEqual("processing", orderProcessing.status);

            //alterar status
            var orderInRoute = ordersServices.AlterarStatusOrderm(tkn, "in_route", responseOrder._id);
            Assert.AreEqual("in_route", orderInRoute.status);

            //alterar status
            var orderDelivered = ordersServices.AlterarStatusOrderm(tkn, "delivered", responseOrder._id);
            Assert.AreEqual("delivered", orderDelivered.status);

            //alterar status
            var orderReceived = ordersServices.AlterarStatusOrderm(tkn, "received", responseOrder._id);
            Assert.AreEqual("received", orderReceived.status);
        }

        [TestMethod]
        public void T13DeveValidarTransicaoDeStatusPlacedForCancelled()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            //alterar status
            var orderCancelled = ordersServices.AlterarStatusOrderm(tkn, "cancelled", responseOrder._id);
            Assert.AreEqual("cancelled", orderCancelled.status);
        }

        //"Not a valid transition from cancelled to delivered."

        [TestMethod]
        public void T14DeveValidarTransicaoDeStatusDePlacedForInRoute()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            //alterar status
            var orderProcessing = ordersServices.AlterarStatusOrderm(tkn, "in_route", responseOrder._id);
            Assert.AreEqual("Not a valid transition from placed to in_route.", orderProcessing.status);
        }

        [TestMethod]
        public void T15DeveValidarTransicaoDeStatusDePlacedForDelivered()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            //alterar status
            var orderProcessing = ordersServices.AlterarStatusOrderm(tkn, "delivered", responseOrder._id);
            Assert.AreEqual("Not a valid transition from placed to delivered.", orderProcessing.status);
        }


        [TestMethod]
        public void T16DeveValidarTransicaoDeStatusDePlacedForReceived()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            //alterar status
            var orderProcessing = ordersServices.AlterarStatusOrderm(tkn, "received", responseOrder._id);
            Assert.AreEqual("Not a valid transition from placed to received.", orderProcessing.status);
        }

        [TestMethod]
        public void T17DeveExcluirPedidoComSucesso()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            ordersServices.DeletaOrderm(tkn, responseOrder._id);
            Assert.AreEqual(204, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T18DeveBuscarPedidoComSucesso()
        {

            OrdersServices ordersServices = new OrdersServices();
            //criar pedido
            var responseOrder = ordersServices.CriarOrderm(700.01, idRefeicao, idRestaurant, tkn);
            Assert.AreEqual("placed", responseOrder.status);

            ordersServices.BuscarOrderm(tkn, responseOrder._id);
            Assert.AreEqual(200, (int)ordersServices.resp.StatusCode);
        }

        [TestMethod]
        public void T19NaoDeveCriarPedidoComTokenInvalido()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrderm(352.87, idRefeicao, idRestaurant, "Bearer 789");

            Assert.AreEqual("401-Unauthorized", responseOrder.message);
        }

        [TestMethod]
        public void T20DeveValidarContratoDaApiOrders()
        {
            OrdersServices ordersServices = new OrdersServices();

            ordersServices.CriarOrderm(352.87, idRefeicao, idRestaurant, tkn);

            JObject json = JObject.Parse(ordersServices.resp.Content);

            //Validar se o json é verdadeiro baseado no contrato da api, caso não sejá vai retornar uma lista dos itens divergentes no response
            Assert.IsTrue(json.IsValid(OrdersSchema.OrdersJson(), out IList<string> messages), String.Join(",", messages));
        }
    }
}
