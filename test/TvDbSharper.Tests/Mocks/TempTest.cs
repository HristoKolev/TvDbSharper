namespace TvDbSharper.Tests.Mocks
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Clients;

    using Xunit;

    public class Dto
    {
    }

    internal class SimpleImpl
    {
        internal static readonly Dictionary<HttpStatusCode, string> ErrorMap = new Dictionary<HttpStatusCode, string>();

        public SimpleImpl(IApiClient apiClient, IParser parser)
        {
            this.ApiClient = apiClient;
            this.Parser = parser;
        }

        private IApiClient ApiClient { get; }

        private IParser Parser { get; }

        public async Task<Dto> GetDtoAsync(CancellationToken cancellationToken)
        {
            var request = new ApiRequest("GET", "/cats");

            var response = await this.ApiClient
                .SendRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return this.Parser.Parse<Dto>(response, ErrorMap);
        }
    }

    public class Test
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetDtoAsync(token))
                .ShouldRequest("GET", "/cats")
                .RunAsync();
        }

        private static ApiTest<SimpleImpl> CreateClient()
        {
            return new ApiTest<SimpleImpl>()
                .WithErrorMap(SimpleImpl.ErrorMap)
                .WithConstructor((client, parser) => new SimpleImpl(client, parser))
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new Dto());
        }
    }
}