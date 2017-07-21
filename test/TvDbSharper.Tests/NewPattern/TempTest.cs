namespace TvDbSharper.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using ConsoleApp2;

    using Xunit;

    public class Dto
    {
    }

    public class SimpleImpl
    {
        internal static Dictionary<HttpStatusCode, string> ErrorMap = new Dictionary<HttpStatusCode, string>();

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

            var response = await this.ApiClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return this.Parser.Parse<Dto>(response, ErrorMap);
        }
    }

    public class Test
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Makes_The_Right_Request()
        {
            return this.CreateClient().WhenCallingAMethod((impl, token) => impl.GetDtoAsync(token)).ShouldRequest("GET", "/cats")
                       .RunAsync();
        }

        public ApiTest<SimpleImpl> CreateClient()
        {
            return new ApiTest<SimpleImpl>((client, parser) => new SimpleImpl(client, parser), SimpleImpl.ErrorMap)
                .SetApiResponse(new ApiResponse()).SetResultObject(new Dto());
        }
    }
}