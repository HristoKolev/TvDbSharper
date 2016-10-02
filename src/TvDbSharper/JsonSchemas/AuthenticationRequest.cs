namespace TvDbSharper.JsonSchemas
{
    public class AuthenticationRequest
    {
        public AuthenticationRequest(string apiKey, string userKey, string username)
        {
            this.ApiKey = apiKey;
            this.UserKey = userKey;
            this.Username = username;
        }

        public AuthenticationRequest()
        {
        }

        public string ApiKey { get; set; }

        public string UserKey { get; set; }

        public string Username { get; set; }
    }
}