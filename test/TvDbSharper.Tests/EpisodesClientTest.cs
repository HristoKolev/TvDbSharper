namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Errors;
    using TvDbSharper.Tests.NewPattern;

    using Xunit;

    public class EpisodesClientTest
    {
        [Theory]
        [InlineData(42)]
        [InlineData(69)]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Makes_The_Right_Request(int episodeId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Episodes.GetAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAsync(episodeId, token))
                .ShouldRequest("GET", "/episodes/" + episodeId)
                .RunAsync();
        }

        [Theory]
        [InlineData(42)]
        [InlineData(69)]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_CT_Makes_The_Right_Request(int episodeId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Episodes.GetAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAsync(episodeId))
                .WithNoCancellationToken()
                .ShouldRequest("GET", "/episodes/" + episodeId)
                .RunAsync();
        }

        private static ApiTest<EpisodesClient> CreateClient()
        {
            return new ApiTest<EpisodesClient>()
                .WithConstructor((client, parser) => new EpisodesClient(client, parser))
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new TvDbResponse<EpisodeRecord>());
        }
    }
}