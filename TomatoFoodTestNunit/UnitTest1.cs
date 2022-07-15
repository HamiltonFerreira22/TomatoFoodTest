namespace TomatoFoodTest
{
    //
    //public class UnitTest1
    //{
    //    public RestClient client;
    //    public RestRequest endpoint;
    //    public IRestResponse resp;

    //    public string urlBase = "http://localhost:3000/api/";
    //    public string endpointRegistro = "users/register";
    //    public string endpointLogin = "users/login";
    //    public string endpointRestaurante = "restaurants";
    //    public string endpointPedido = "orders";
    //    public string nomeCadastro, emailCadastro, senhaCadastro, telefoneCadastro;
    //    public string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");


    //    public void body(object body)
    //    {
    //        endpoint.RequestFormat = DataFormat.Json;
    //        endpoint.AddJsonBody(body);
    //    }
    //    [Test]
    //    // É necesssario que ele rode antes de todos os testes por isso o metodo TestInitialize foi implementado
    //    public void GerarDadosTeste()
    //    {
    //        var faker = new Faker("pt_BR");

    //        var nomeFaker = faker.Name.FirstName();
    //        var emailFaker = faker.Internet.Email();
    //        var senhaFaker = faker.Internet.Password();
    //        var telefoneFaker = faker.Phone.PhoneNumber();  

    //        nomeCadastro = nomeFaker;
    //        emailCadastro = emailFaker;
    //        senhaCadastro = senhaFaker;
    //        telefoneCadastro = telefoneFaker;
    //    }


    //    [Test]
    //    public void T01DeveCadastrarUmRegistroComFuncaoGerente()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest(endpointRegistro);
    //        endpoint.Method = Method.POST;
    //        endpoint.RequestFormat = DataFormat.Json;
    //        body(new
    //        {
    //            name = nomeCadastro,
    //            email = emailCadastro,
    //            password = senhaCadastro,
    //            password2 = senhaCadastro,
    //            role = "manager"
    //        });

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //        Assert.AreEqual(200,(int)resp.StatusCode);  

    //        dynamic obj = JProperty.Parse(resp.Content);

    //        var funcao = obj["role"];
    //        var id = obj["_id"]; 
    //        var nome = obj["name"]; 
    //        var password = obj["password"];
    //        var email = obj["email"];
    //        var data = obj["date"];
    //        var versao = obj["__v"];

    //        Assert.AreEqual("manager",Convert.ToString(funcao));
    //        Assert.IsNotNull(id);
    //        Assert.AreEqual(nomeCadastro, Convert.ToString(nome));
    //        Assert.IsNotNull(password);
    //        Assert.AreEqual(emailCadastro, Convert.ToString(email));
    //        Assert.AreEqual(dataAtual, Convert.ToString(data).Substring(0,10));
    //        Assert.AreEqual(0, Convert.ToInt32(versao));

    //    }

    //    [Test]
    //    public void T02DeveRealizarLoginComFuncaoGerente()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest(endpointLogin);
    //        endpoint.Method = Method.POST;
    //        body(new
    //        {
    //            email = "fernando@gmail.com",
    //            password = "hamilton1"
    //        });

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //    }

    //    [Test]
    //    public void T03DeveCadastrarRestaurante()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest(endpointRestaurante);
    //        endpoint.Method = Method.POST;
    //        endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyN2YxMjdhOGNhMTE5MWMyYzA5OWY2ZiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY1MjQ5NTIxNiwiZXhwIjoxNjg0MDUyMTQyfQ.g5laxhqoHlZhJSydoDZ4XHtHfClbQDnzkNDt1tyEDmM");

    //        body(new
    //        {
    //            name = "Coco Bambu",
    //            type = "Restaurante Brasileiro",
    //            description = "O Melhor ",
    //            _meals = new List<object>()
    //            {
    //              new  { name = "Arroz",price = "24.90",description = "Arroz carreiteiro"},
    //              new { name = "Feijão",price = "35.98",description = "Feijão Preto"}
    //            }
    //        });

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //    }

    //    [Test]
    //    public void T04DeveRealizarUmPedido()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest(endpointPedido);
    //        endpoint.Method = Method.POST;
    //        endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyN2YxMjdhOGNhMTE5MWMyYzA5OWY2ZiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY1MjQ5NTIxNiwiZXhwIjoxNjg0MDUyMTQyfQ.g5laxhqoHlZhJSydoDZ4XHtHfClbQDnzkNDt1tyEDmM");

    //        body(new
    //        {
    //            total_amount = 1217.6,
    //            _meals = new ArrayList(){ "627f15688ca1191c2c099f78","627f15688ca1191c2c099f79"},
    //            _restaurant = "627f156b8ca1191c2c099f7c"

    //        }) ;

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //    }

    //    [Test]
    //    public void T05DeveBuscarUmPedido()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest("orders/627ff951c5eb7b1eb07b7847");
    //        endpoint.Method = Method.GET;
    //        endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyN2YxMjdhOGNhMTE5MWMyYzA5OWY2ZiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY1MjQ5NTIxNiwiZXhwIjoxNjg0MDUyMTQyfQ.g5laxhqoHlZhJSydoDZ4XHtHfClbQDnzkNDt1tyEDmM");

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //    }

    //    [Test]
    //    public void T06DeveAlterarStatusDoPedido()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest("orders/627ff951c5eb7b1eb07b7847");
    //        endpoint.Method = Method.PUT;
    //        endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyN2YxMjdhOGNhMTE5MWMyYzA5OWY2ZiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY1MjQ5NTIxNiwiZXhwIjoxNjg0MDUyMTQyfQ.g5laxhqoHlZhJSydoDZ4XHtHfClbQDnzkNDt1tyEDmM");
    //        body(new
    //        {
    //            status = "cancelled",
    //        });

    //        resp = client.Execute(endpoint);

    //        JObject resposta = JObject.Parse(resp.Content);
    //        Console.WriteLine(resposta);

    //    }

    //    [Test]
    //    public void T07DeveDeletarUmPedido()
    //    {
    //        client = new RestClient(urlBase);
    //        endpoint = new RestRequest("orders/627f21cb8ca1191c2c099f96");
    //        endpoint.Method = Method.DELETE;
    //        endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyN2YxMjdhOGNhMTE5MWMyYzA5OWY2ZiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY1MjQ5NTIxNiwiZXhwIjoxNjg0MDUyMTQyfQ.g5laxhqoHlZhJSydoDZ4XHtHfClbQDnzkNDt1tyEDmM");           

    //        resp = client.Execute(endpoint);
    //        //Assertiva para pegar o status de request.
    //        Assert.AreEqual(204,(int)resp.StatusCode);

    //    }
    //}
}