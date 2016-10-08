namespace TvDbSharper.Clients.Authentication.Json
{
    public class AuthenticationRequest
    {
        public AuthenticationRequest(string apiKey, string username, string userKey)
        {
            this.ApiKey = apiKey;
            this.Username = username;
            this.UserKey = userKey;
        }

        public AuthenticationRequest()
        {
        }

        public string ApiKey { get; set; }

        public string UserKey { get; set; }

        public string Username { get; set; }
    }
}