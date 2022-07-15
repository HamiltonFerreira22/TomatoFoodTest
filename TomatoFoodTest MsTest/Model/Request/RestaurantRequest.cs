
namespace TomatoFoodTest.Model.Request
{
    public class RestaurantRequest
    {
        public string name { get; set; }   
        public string description { get; set; } 
        public string type { get; set; }   
        public List<Meal> _meals { get; set; }
    }
    //para mapeamento de lista cria-se a classe da lista e mapea entro dela como no exemplo
    public class Meal
    {
        public string description { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }
}
