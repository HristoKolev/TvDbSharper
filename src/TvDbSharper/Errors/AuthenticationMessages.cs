namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class AuthenticationMessages : IAuthenticationMessages
    {
        public IReadOnlyDictionary<int, string> AuthenticateAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Invalid credentials" }
        };

        public IReadOnlyDictionary<int, string> RefreshTokenAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" }
        };
    }
}