namespace ManualTests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TvDbSharper;

    internal static class Program
    {
        private static async Task Main()
        {
            // Client
            var client = new TvDbClient();
            var authData = JsonConvert.DeserializeObject<AuthenticationData>(await File.ReadAllTextAsync("../../../auth.json"));
            await client.Login(authData!.ApiKey, authData.Pin);

            // // Artwork
            // Test("Artwork(62803637)", await client.Artwork(62803637));
            // Test("ArtworkExtended(62803637)", await client.ArtworkExtended(62803637));
            // // Test("ArtworkTranslation(62803637, 'eng')", await client.ArtworkTranslation(62803637, "eng")); // what do I pass as a language ???
            //
            // // Artwork Statuses
            // Test("ArtworkStatuses", await client.ArtworkStatuses());
            //
            // // Artwork Types
            // Test("ArtworkTypes", await client.ArtworkTypes());
            //
            // // Awards
            // Test("Awards", await client.Awards());
            // Test("Award(1)", await client.Award(1));
            // Test("AwardExtended(1)", await client.AwardExtended(1));
            //
            // // Award Categories
            // Test("AwardCategory(1)", await client.AwardCategory(1));
            // Test("AwardCategoryExtended(1)", await client.AwardCategoryExtended(1));
            //
            // // Characters
            // Test("Character(67482807)", await client.Character(67482807));
            //
            // // Companies
            // Test("Companies", await client.Companies());
            // Test("CompanyTypes", await client.CompanyTypes());
            // Test("Company(1)", await client.Company(1));
            //
            // // Content Ratings
            // Test("ContentRatings()", await client.ContentRatings());
            //
            // // Countries
            // Test("Countries()", await client.Countries());
            //
            // // Entity Types
            // Test("EntityTypes()", await client.EntityTypes());
            //
            // // Episodes
            // Test("Episode(7676782)", await client.Episode(7676782));
            // Test("EpisodeExtended(7676782)", await client.EpisodeExtended(7676782));
            // Test("EpisodeTranslation(7676782, 'deu')", await client.EpisodeTranslation(7676782, "deu"));
            //
            // // Genders
            // Test("Genders()", await client.Genders());
            //
            // // Genres
            // Test("Genres()", await client.Genres());
            // Test("Genre(31)", await client.Genre(31));
            //
            // // Languages
            // Test("Languages()", await client.Languages());
            //
            // // Lists
            // Test("Lists()", await client.Lists());
            // Test("Lists(6007)", await client.List(6007));
            // Test("ListExtended(6007)", await client.ListExtended(6007));
            // Test("ListTranslation(6007, 'eng')", await client.ListTranslation(6007, "eng"));
            
            // // Movies
            // Test("Movies()", await client.Movies());
            // Test("Movie(503)", await client.Movie(503));
            // Test("MovieExtended(503)", await client.MovieExtended(503));
            // Test("MovieTranslation(503, 'eng')", await client.MovieTranslation(503, "eng"));
            
            // // Movie Statuses
            // Test("MovieStatuses()", await client.MovieStatuses());
            
            // People
            // Test("People(310602)", await client.People(310602));
            Test("PeopleExtended(310602)", await client.PeopleExtended(310602));
            
            
            
            
            
            
            
            
            

            // Test("Search", await client.Search(new SearchOptionalParams { Query = "stargate" }));

            // int seriesID = 83237;

            // var episode = (await client.Episodes.GetAsync(418910)).Data;
            //
            // var allLanguages = (await client.Languages.GetAllAsync()).Data;
            //
            // var language = (await client.Languages.GetAsync(allLanguages.First().Id!.Value)).Data;
            //
            // var searchResult = (await client.Search.SearchSeriesAsync("stargate", SearchParameter.Name)).Data;
            //
            // var searchBySlug = (await client.Search.SearchSeriesBySlugAsync("stargate-universe")).Data;
            //
            // var searchByImdb = (await client.Search.SearchSeriesByImdbIdAsync("tt1286039")).Data;
            //
            // var searchByZap = (await client.Search.SearchSeriesByZap2ItIdAsync("EP01183982")).Data;
            //
            // var searchByZap2 = (await client.Search.SearchSeriesAsync("EP01183982", "zap2itId")).Data;
            //
            // var show = (await client.Series.GetAsync(seriesID)).Data;
            //
            // var actors = (await client.Series.GetActorsAsync(seriesID)).Data;
            //
            // var allEpisodes = (await client.Series.GetEpisodesAsync(seriesID, 0)).Data;
            //
            // var headers = (await client.Series.GetHeadersAsync(seriesID));
            //
            // var images = (await client.Series.GetImagesAsync(seriesID, new ImagesQuery {KeyType = KeyType.Poster})).Data;
            //
            // var images2 = (await client.Series.GetImagesAsync(seriesID, new ImagesQueryAlternative {KeyType = "poster"})).Data;
            //
            // var summaries = (await client.Series.GetEpisodesSummaryAsync(seriesID)).Data;
            //
            // var imageSummaries = (await client.Series.GetImagesSummaryAsync(seriesID)).Data;
            //
            // var imageSummaries2 = (await client.Series.GetImagesSummaryAsync(253463)).Data;
            //
            // var updates = (await client.Updates.GetAsync(DateTime.Now.Subtract(TimeSpan.FromDays(1)), DateTime.Now)).Data;
            //
            // // user API
            //
            // var userData = (await client.Users.GetAsync()).Data;
            //
            // // var allRatings = (await client.Users.GetRatingsAsync(RatingType.Series)).Data;
            //
            // var ratings = (await client.Users.AddRatingAsync(RatingType.Series, seriesID, 10)).Data;
            //
            // await client.Users.RemoveRatingAsync(RatingType.Series, seriesID);
            //
            // var fav = (await client.Users.GetFavoritesAsync()).Data;
            //
            // var addFav = (await client.Users.AddToFavoritesAsync(seriesID)).Data;
            //
            // var remFav = (await client.Users.RemoveFromFavoritesAsync(seriesID)).Data;
            //
            // Console.WriteLine("Done.");
        }

        private static void Test(string tag, object obj)
        {
            Console.WriteLine();
            Console.WriteLine($"{tag} => {JsonConvert.SerializeObject(obj, Formatting.Indented)}");
        }
    }

    public class AuthenticationData
    {
        public string ApiKey { get; set; }

        public string Pin { get; set; }
    }
}
