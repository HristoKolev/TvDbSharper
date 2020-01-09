namespace TvDbSharper.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Data;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class SeriesClientTest
    {
        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Actor[]>())
                .WhenCallingAMethod((impl, token) => impl.GetActorsAsync(seriesId, token))
                .ShouldRequest("GET", $"/series/{seriesId}/actors")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Actor[]>())
                .WhenCallingAMethod((impl, token) => impl.GetActorsAsync(seriesId))
                .ShouldRequest("GET", $"/series/{seriesId}/actors")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Series>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync(seriesId, token))
                .ShouldRequest("GET", $"/series/{seriesId}")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Series>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync(seriesId))
                .ShouldRequest("GET", $"/series/{seriesId}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [InlineData(1, SeriesFilter.Id | SeriesFilter.Genre, "genre,id")]
        [InlineData(2, SeriesFilter.Added | SeriesFilter.AddedBy, "added,addedBy")]
        [InlineData(3, SeriesFilter.Banner | SeriesFilter.Rating, "banner,rating")]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_Filter_Makes_The_Right_Request(int seriesId, SeriesFilter filter, string stringFilter)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Series>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync(seriesId, filter, token))
                .ShouldRequest("GET", $"/series/{seriesId}/filter?keys={stringFilter}")
                .RunAsync();
        }

        [Theory]
        [InlineData(1, SeriesFilter.Id | SeriesFilter.Genre, "genre,id")]
        [InlineData(2, SeriesFilter.Added | SeriesFilter.AddedBy, "added,addedBy")]
        [InlineData(3, SeriesFilter.Banner | SeriesFilter.Rating, "banner,rating")]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_Filter_With_CT_Makes_The_Right_Request(int seriesId, SeriesFilter filter, string stringFilter)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<Series>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync(seriesId, filter))
                .ShouldRequest("GET", $"/series/{seriesId}/filter?keys={stringFilter}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(3, -10, 1)]
        [InlineData(4, 0, 1)]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesAsync_Makes_The_Right_Request(int seriesId, int page, int actualPage)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodeRecord[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesAsync(seriesId, page, token))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes?page={actualPage}")
                .RunAsync();
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(3, -10, 1)]
        [InlineData(4, 0, 1)]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesAsync_Without_CT_Makes_The_Right_Request(int seriesId, int page, int actualPage)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodeRecord[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesAsync(seriesId, page))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes?page={actualPage}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [InlineData(1, 2, 2, 1, 2)]
        [InlineData(2, 3, 3, 3, 4)]
        [InlineData(3, -10, 1, 5, 6)]
        [InlineData(4, 0, 1, 7, 8)]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesAsync_With_Query_Makes_The_Right_Request(int seriesId, int page, int actualPage, int aired, int dvd)
        {
            var query = new EpisodeQuery { AiredEpisode = aired, DvdEpisode = dvd };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodeRecord[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesAsync(seriesId, page, query, token))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes/query?page={actualPage}&airedEpisode={aired}&dvdEpisode={dvd}")
                .RunAsync();
        }

        [Theory]
        [InlineData(1, 2, 2, 1, 2)]
        [InlineData(2, 3, 3, 3, 4)]
        [InlineData(3, -10, 1, 5, 6)]
        [InlineData(4, 0, 1, 7, 8)]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesAsync_With_Query_Without_CT_Makes_The_Right_Request(int seriesId, int page, int actualPage, int aired, int dvd)
        {
            var query = new EpisodeQuery { AiredEpisode = aired, DvdEpisode = dvd };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodeRecord[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesAsync(seriesId, page, query))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes/query?page={actualPage}&airedEpisode={aired}&dvdEpisode={dvd}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesSummaryAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodesSummary>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesSummaryAsync(seriesId, token))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes/summary")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesSummaryAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<EpisodesSummary>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesSummaryAsync(seriesId))
                .ShouldRequest("GET", $"/series/{seriesId}/episodes/summary")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [InlineData(1, KeyType.Series, "1", "2")]
        [InlineData(2, KeyType.Fanart, "3", "4")]
        [InlineData(3, KeyType.Poster, "5", "6")]
        [InlineData(4, KeyType.Season, "7", "8")]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesAsync_Makes_The_Right_Request(int seriesId, KeyType keyType, string resolution, string subKey)
        {
            var query = new ImagesQuery { Resolution = resolution, SubKey = subKey, KeyType = keyType };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetImagesAsync)
                .SetResultObject(new TvDbResponse<Image[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesAsync(seriesId, query, token))
                .ShouldRequest("GET", $"/series/{seriesId}/images/query?keyType={keyType}&resolution={resolution}&subKey={subKey}")
                .RunAsync();
        }

        [Theory]
        [InlineData(1, KeyType.Series, "1", "2")]
        [InlineData(2, KeyType.Fanart, "3", "4")]
        [InlineData(3, KeyType.Poster, "5", "6")]
        [InlineData(4, KeyType.Season, "7", "8")]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesAsync_Without_CT_Makes_The_Right_Request(int seriesId, KeyType keyType, string resolution, string subKey)
        {
            var query = new ImagesQuery { Resolution = resolution, SubKey = subKey, KeyType = keyType };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetImagesAsync)
                .SetResultObject(new TvDbResponse<Image[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesAsync(seriesId, query))
                .ShouldRequest("GET", $"/series/{seriesId}/images/query?keyType={keyType}&resolution={resolution}&subKey={subKey}")
                .WithNoCancellationToken()
                .RunAsync();
        }
        
        [Theory]
        [InlineData(1, "series", "1", "2")]
        [InlineData(2, "fanart", "3", "4")]
        [InlineData(3, "poster", "5", "6")]
        [InlineData(4, "season", "7", "8")]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesAsync_Alternative_Makes_The_Right_Request(int seriesId, string keyType, string resolution, string subKey)
        {
            var query = new ImagesQueryAlternative { Resolution = resolution, SubKey = subKey, KeyType = keyType };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetImagesAsync)
                .SetResultObject(new TvDbResponse<Image[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesAsync(seriesId, query, token))
                .ShouldRequest("GET", $"/series/{seriesId}/images/query?keyType={keyType}&resolution={resolution}&subKey={subKey}")
                .RunAsync();
        }

        [Theory]
        [InlineData(1, "series", "1", "2")]
        [InlineData(2, "fanart", "3", "4")]
        [InlineData(3, "poster", "5", "6")]
        [InlineData(4, "season", "7", "8")]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesAsync_Alternative_Without_CT_Makes_The_Right_Request(int seriesId, string keyType, string resolution, string subKey)
        {
            var query = new ImagesQueryAlternative { Resolution = resolution, SubKey = subKey, KeyType = keyType };

            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetImagesAsync)
                .SetResultObject(new TvDbResponse<Image[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesAsync(seriesId, query))
                .ShouldRequest("GET", $"/series/{seriesId}/images/query?keyType={keyType}&resolution={resolution}&subKey={subKey}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesSummaryAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<ImagesSummary>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesSummaryAsync(seriesId, token))
                .ShouldRequest("GET", $"/series/{seriesId}/images")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesSummaryAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Series.GetAsync)
                .SetResultObject(new TvDbResponse<ImagesSummary>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesSummaryAsync(seriesId))
                .ShouldRequest("GET", $"/series/{seriesId}/images")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetHeadersAsync_Makes_The_Right_Request(int seriesId)
        {
            var headers = new Dictionary<string, string>();

            var response = new ApiResponse
            {
                Headers = headers
            };

            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetHeadersAsync(seriesId, token))
                .ShouldRequest("HEAD", $"/series/{seriesId}")
                .SetApiResponse(response)
                .ShouldNotUseParser()
                .ShouldIgnoreParserResult()
                .ShouldReturn(headers)
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task GetHeadersAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            var headers = new Dictionary<string, string>();

            var response = new ApiResponse
            {
                Headers = headers
            };

            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetHeadersAsync(seriesId))
                .ShouldRequest("HEAD", $"/series/{seriesId}")
                .SetApiResponse(response)
                .ShouldNotUseParser()
                .ShouldIgnoreParserResult()
                .WithNoCancellationToken()
                .ShouldReturn(headers)
                .RunAsync();
        }

        private static ApiTest<SeriesClient> CreateClient()
        {
            return new ApiTest<SeriesClient>()
                .WithConstructor((client, parser) => new SeriesClient(client, parser))
                .SetApiResponse(new ApiResponse());
        }
    }
}