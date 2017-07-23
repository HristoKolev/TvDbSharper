namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Errors;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class EpisodesClientTest
    {
        [Theory]
        [InlineData(1), InlineData(2), InlineData(3)]

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
        [InlineData(1), InlineData(2), InlineData(3)]

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