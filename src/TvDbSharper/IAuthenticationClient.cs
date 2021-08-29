namespace TvDbSharper
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Used for obtaining and refreshing your JWT token
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// <para>Gets or sets the authentication token that gets stored after calling <see cref="AuthenticateAsync(AuthenticationData, CancellationToken)" /></para>
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// <para>[POST /login]</para>
        /// <para>Authenticates the user given an authentication data and retrieves a session token.</para>
        /// <para>Call once before calling any other method.</para>
        /// </summary>
        /// <param name="authenticationData">The data required for authentication</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task AuthenticateAsync(AuthenticationData authenticationData, CancellationToken cancellationToken);

        /// <summary>
        /// <para>[POST /login]</para>
        /// <para>Authenticates the user given an authentication data and retrieves a session token.</para>
        /// <para>Call once before calling any other method.</para>
        /// </summary>
        /// <param name="authenticationData">The data required for authentication</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task AuthenticateAsync(AuthenticationData authenticationData);
    }
}
