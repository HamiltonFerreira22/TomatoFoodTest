
namespace TomatoFoodTest.Model.Response
{
    public  class LoginResponse
    {
        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("passwordincorrect")]
        public string passwordincorrect { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("emailnotfound")]
        public string emailnotfound { get; set; }

        
    }
}
