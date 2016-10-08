namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class AuthenticationMessages : IAuthenticationMessages
    {
        public IDictionary<int, string> AuthenticateAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Invalid credentials" }
        };

        public IDictionary<int, string> RefreshTokenAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" }
        };
    }
}