namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Data;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class EpisodesClientTest
    {
        [Theory]
        [ClassData(typeof(IntegerData))]

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
        [ClassData(typeof(IntegerData))]

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