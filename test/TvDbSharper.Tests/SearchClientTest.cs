namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Errors;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class SearchClientTest
    {
        [Theory]
        [InlineData("Doctor Who", "Doctor+Who")]
        [InlineData("Sherlock", "Sherlock")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Makes_The_Right_Request(string name, string encodedName)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesAsync(name, SearchParameter.Name, token))
                .ShouldRequest("GET", $"/search/series?name={encodedName}")
                .RunAsync();
        }

        [Theory]
        [InlineData("Doctor Who", "Doctor+Who")]
        [InlineData("Sherlock", "Sherlock")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Without_CT_Makes_The_Right_Request(string name, string encodedName)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesAsync(name, SearchParameter.Name))
                .ShouldRequest("GET", $"/search/series?name={encodedName}")
                .WithNoCancellationToken()
                .RunAsync();
        }


        private static ApiTest<SearchClient> CreateClient()
        {
            return new ApiTest<SearchClient>()
                .WithConstructor((client, parser) => new SearchClient(client, parser))
                .WithErrorMap(ErrorMessages.Search.SearchSeriesAsync)
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new TvDbResponse<SeriesSearchResult[]>());
        }
    }
}