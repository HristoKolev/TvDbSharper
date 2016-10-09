namespace TvDbSharper.Clients.Authentication
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Clients.Authentication.Json;

    public interface IAuthenticationClient
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task AuthenticateAsync(string apiKey, string username, string userKey, CancellationToken cancellationToken);

        Task AuthenticateAsync(string apiKey, string username, string value);

        Task AuthenticateAsync(AuthenticationRequest authenticationRequest);

        Task RefreshTokenAsync(CancellationToken cancellationToken);

        Task RefreshTokenAsync();
    }
}