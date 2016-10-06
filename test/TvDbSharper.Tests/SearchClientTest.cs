namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonApi.Search;
    using TvDbSharper.JsonApi.Search.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class SearchClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeries_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SearchClient(jsonClient);

            const SearchParameter ParameterKey = SearchParameter.Name;
            const string ParameterValue = "Doctor Who";

            const string Route = "/search/series?name=Doctor Who";

            var expectedData = new TvDbResponse<SeriesSearchResult[]>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetSeriesAsync(ParameterValue, ParameterKey, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesSearchResult[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}