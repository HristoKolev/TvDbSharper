namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IAuthenticationMessages
    {
        IReadOnlyDictionary<int, string> AuthenticateAsync { get; }

        IReadOnlyDictionary<int, string> RefreshTokenAsync { get; }
    }
}