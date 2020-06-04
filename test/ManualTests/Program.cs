using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvDbSharper;
using TvDbSharper.Dto;

namespace ManualTests
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            
            var client = new TvDbClient(httpClient);

            var authenticationData = JsonConvert.DeserializeObject<AuthenticationData>(await File.ReadAllTextAsync("../../../auth.json"));
            
            await client.Authentication.AuthenticateAsync(authenticationData);
            
            client = new TvDbClient(httpClient);

            int seriesID = 83237;
            
            await client.Authentication.RefreshTokenAsync();
            
            var episode = (await client.Episodes.GetAsync(418910)).Data;
            
            var allLanguages = (await client.Languages.GetAllAsync()).Data;
            
            var language = (await client.Languages.GetAsync(allLanguages.First().Id.Value)).Data;
            
            var searchResult = (await client.Search.SearchSeriesAsync("stargate", SearchParameter.Name)).Data;
            
            var searchBySlug = (await client.Search.SearchSeriesBySlugAsync("stargate-universe")).Data;
            
            var searchByImdb = (await client.Search.SearchSeriesByImdbIdAsync("tt1286039")).Data;
            
            var searchByZap = (await client.Search.SearchSeriesByZap2ItIdAsync("EP01183982")).Data;
            
            var searchByZap2 = (await client.Search.SearchSeriesAsync("EP01183982", "zap2itId")).Data;
            
            var show = (await client.Series.GetAsync(seriesID)).Data;
            
            var actors = (await client.Series.GetActorsAsync(seriesID)).Data;
            
            var allEpisodes = (await client.Series.GetEpisodesAsync(seriesID, 0)).Data;
            
            var headers = (await client.Series.GetHeadersAsync(seriesID));
            
            var images = (await client.Series.GetImagesAsync(seriesID, new ImagesQuery() {KeyType = KeyType.Poster})).Data;
            
            var images2 = (await client.Series.GetImagesAsync(seriesID, new ImagesQueryAlternative() {KeyType = "poster"})).Data;
            
            var summaries = (await client.Series.GetEpisodesSummaryAsync(seriesID)).Data;
            
            var imageSummaries = (await client.Series.GetImagesSummaryAsync(seriesID)).Data;
            
            var updates = (await client.Updates.GetAsync(DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now)).Data;
            
            // user API

            var userData = (await client.Users.GetAsync()).Data;

            // var allRatings = (await client.Users.GetRatingsAsync(RatingType.Series)).Data;
            
            var ratings = (await client.Users.AddRatingAsync(RatingType.Series, seriesID, 10)).Data;
            
            await client.Users.RemoveRatingAsync(RatingType.Series, seriesID);

            var fav = (await client.Users.GetFavoritesAsync()).Data;

            var addFav = (await client.Users.AddToFavoritesAsync(seriesID)).Data;

            var remFav = (await client.Users.RemoveFromFavoritesAsync(seriesID)).Data;

            Console.WriteLine("Done.");
        }
    }
}