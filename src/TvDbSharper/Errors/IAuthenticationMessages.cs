namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IAuthenticationMessages
    {
        IDictionary<int, string> AuthenticateAsync { get; }

        IDictionary<int, string> RefreshTokenAsync { get; }
    }
}