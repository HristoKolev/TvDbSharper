namespace TvDbSharper.Api.Authentication
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Authentication.Json;

    public interface IAuthenticationClient
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task RefreshTokenAsync(CancellationToken cancellationToken);
    }
}