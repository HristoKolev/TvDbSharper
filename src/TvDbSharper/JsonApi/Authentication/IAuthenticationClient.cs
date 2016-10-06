namespace TvDbSharper.JsonApi.Authentication
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Authentication.Json;

    public interface IAuthenticationClient
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task RefreshTokenAsync(CancellationToken cancellationToken);
    }
}