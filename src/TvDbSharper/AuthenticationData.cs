namespace TvDbSharper
{
    using Newtonsoft.Json;

    public class AuthenticationData
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }

    public class AuthenticationResponseData
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
