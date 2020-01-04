namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
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


        [Theory]
        [InlineData("Doctor Who", "Doctor+Who")]
        [InlineData("Sherlock", "Sherlock")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByNameAsync_Makes_The_Right_Request(string name, string encodedName)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByNameAsync(name, token))
                .ShouldRequest("GET", $"/search/series?name={encodedName}")
                .RunAsync();
        }

        [Theory]
        [InlineData("Doctor Who", "Doctor+Who")]
        [InlineData("Sherlock", "Sherlock")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByNameAsync_Without_CT_Makes_The_Right_Request(string name, string encodedName)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByNameAsync(name))
                .ShouldRequest("GET", $"/search/series?name={encodedName}")
                .WithNoCancellationToken()
                .RunAsync();
        }


        [Theory]
        [InlineData("tt0436992")]
        [InlineData("tt0118480")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByImdbIdAsync_Makes_The_Right_Request(string imdbId)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByImdbIdAsync(imdbId, token))
                .ShouldRequest("GET", $"/search/series?imdbId={imdbId}")
                .RunAsync();
        }

        [Theory]
        [InlineData("tt0436992")]
        [InlineData("tt0118480")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByImdbIdAsync_Without_CT_Makes_The_Right_Request(string imdbId)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByImdbIdAsync(imdbId))
                .ShouldRequest("GET", $"/search/series?imdbId={imdbId}")
                .WithNoCancellationToken()
                .RunAsync();
        }


        [Theory]
        [InlineData("EP00225421")]
        [InlineData("EP00750178")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByZap2ItIdAsync_Makes_The_Right_Request(string zap2itId)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByZap2ItIdAsync(zap2itId, token))
                .ShouldRequest("GET", $"/search/series?zap2itId={zap2itId}")
                .RunAsync();
        }

        [Theory]
        [InlineData("EP00225421")]
        [InlineData("EP00750178")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesByZap2ItIdAsync_Without_CT_Makes_The_Right_Request(string zap2itId)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesByZap2ItIdAsync(zap2itId))
                .ShouldRequest("GET", $"/search/series?zap2itId={zap2itId}")
                .WithNoCancellationToken()
                .RunAsync();
        }
        
        [Theory]
        [InlineData("stargate-universe")]
        [InlineData("stargate-sg-1")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesBySlugAsync_Makes_The_Right_Request(string slug)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesBySlugAsync(slug, token))
                .ShouldRequest("GET", $"/search/series?slug={slug}")
                .RunAsync();
        }

        [Theory]
        [InlineData("stargate-universe")]
        [InlineData("stargate-sg-1")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesBySlugAsync_Without_CT_Makes_The_Right_Request(string slug)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesBySlugAsync(slug))
                .ShouldRequest("GET", $"/search/series?slug={slug}")
                .WithNoCancellationToken()
                .RunAsync();
        }
        
        [Theory]
        [InlineData("stargate-universe", "slug")]
        [InlineData("stargate-sg-1", "slug")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_With_String_Param_Makes_The_Right_Request(string value, string key)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesAsync(value, key, token))
                .ShouldRequest("GET", $"/search/series?{key}={value}")
                .RunAsync();
        }

        [Theory]
        [InlineData("stargate-universe", "slug")]
        [InlineData("stargate-sg-1", "slug")]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_With_String_Param_Without_CT_Makes_The_Right_Request(string value, string key)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.SearchSeriesAsync(value, key))
                .ShouldRequest("GET", $"/search/series?{key}={value}")
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