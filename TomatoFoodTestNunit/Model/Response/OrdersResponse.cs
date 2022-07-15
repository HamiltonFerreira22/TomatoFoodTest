
namespace TomatoFoodTest.Model.Response
{
    public  class OrdersResponse
    {
        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("subtotal")]
        public double subtotal { get; set; }

        [JsonProperty("total_amount")]
        public double total_amount { get; set; }

        [JsonProperty("total_discount")]
        public double total_discount { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("_meals")]
        public string[] _meals { get; set; }

        [JsonProperty("_restaurant")]
        public string _restaurant { get; set; }

        [JsonProperty("_user")]
        public string _user { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
