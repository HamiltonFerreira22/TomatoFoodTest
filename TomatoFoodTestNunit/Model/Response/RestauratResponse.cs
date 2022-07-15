
namespace TomatoFoodTest.Model.Response
{
    public class RestaurantResponse
    {
        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("_meals")]
        public string[] _meals { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
