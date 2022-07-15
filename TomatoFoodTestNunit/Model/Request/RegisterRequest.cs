
namespace TomatoFoodTest.Model.Request
{
    public class RegisterRequest
    {
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }       
        public string password2 { get; set; }   
        public string role { get; set; }   
    }
}
