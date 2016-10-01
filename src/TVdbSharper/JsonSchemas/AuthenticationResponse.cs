namespace TVdbSharper.JsonSchemas
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse()
        {
        }

        public AuthenticationResponse(string token)
        {
            this.token = token;
        }

        // ReSharper disable once InconsistentNaming
        public string token { get; set; }
    }
}