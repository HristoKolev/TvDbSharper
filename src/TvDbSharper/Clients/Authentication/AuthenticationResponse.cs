namespace TvDbSharper.Clients.Authentication
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