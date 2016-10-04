namespace TvDbSharper.Authentication.Json
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse()
        {
        }

        public AuthenticationResponse(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}