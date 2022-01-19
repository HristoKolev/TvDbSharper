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
            
            // Artwork
            Test("Artwork(62803637)", await client.Artwork(62803637));
            Test("ArtworkExtended(62803637)", await client.ArtworkExtended(62803637));
            
            // Artwork Statuses
            Test("ArtworkStatuses", await client.ArtworkStatuses());
            
            // Artwork Types
            Test("ArtworkTypes", await client.ArtworkTypes());
            
            // Awards
            Test("Awards", await client.Awards());
            Test("Award(1)", await client.Award(1));
            Test("AwardExtended(1)", await client.AwardExtended(1));
            
            // Award Categories
            Test("AwardCategory(1)", await client.AwardCategory(1));
            Test("AwardCategoryExtended(1)", await client.AwardCategoryExtended(1));
            
            // Characters
            Test("Character(67482807)", await client.Character(67482807));
            
            // Companies
            Test("Companies", await client.Companies());
            Test("CompanyTypes", await client.CompanyTypes());
            Test("Company(1)", await client.Company(1));
            
            // Content Ratings
            Test("ContentRatings()", await client.ContentRatings());
            
            // Countries
            Test("Countries()", await client.Countries());
            
            // Entity Types
            Test("EntityTypes()", await client.EntityTypes());
            
            // Episodes
            Test("Episode(7676782)", await client.Episode(7676782));
            Test("EpisodeExtended(7676782)", await client.EpisodeExtended(7676782));
            Test("EpisodeTranslation(7676782, 'deu')", await client.EpisodeTranslation(7676782, "deu"));
            
            // Genders
            Test("Genders()", await client.Genders());
            
            // Genres
            Test("Genres()", await client.Genres());
            Test("Genre(31)", await client.Genre(31));
            
            // InspirationTypes
            Test("InspirationTypes()", await client.InspirationTypes());
            
            // Languages
            Test("Languages()", await client.Languages());
            
            // Lists
            Test("Lists()", await client.Lists());
            Test("Lists(6007)", await client.List(6007));
            Test("ListExtended(6007)", await client.ListExtended(6007));
            Test("ListTranslation(6007, 'eng')", await client.ListTranslation(6007, "eng"));
            
            // Movies
            Test("Movies()", await client.Movies());
            Test("Movie(165)", await client.Movie(503));
            Test("MovieExtended(165)", await client.MovieExtended(165));
            Test("MovieTranslation(165, 'eng')", await client.MovieTranslation(165, "eng"));

            // Movie Statuses
            Test("MovieStatuses()", await client.MovieStatuses());


            // People
            Test("People(310602)", await client.People(310602));
            Test("PeopleExtended(310602)", await client.PeopleExtended(310602));
            // Test("PeopleTranslation(310602, 'eng')", await client.PeopleTranslation(310602, "eng"));

            // Search 
            Test("Search(Query = stargate)", await client.Search(new SearchOptionalParams { Query = "stargate"}));

            // Seasons
            Test("Seasons()", await client.Seasons());
            Test("Season(530667)", await client.Season(530667));
            Test("SeasonExtended(530667)", await client.SeasonExtended(530667));
            Test("SeasonTypes()", await client.SeasonTypes());
            // Test("SeasonTranslation(530667, 'eng')", await client.SeasonTranslation(530667, "eng"));

            // Series
            Test("AllSeries()", await client.AllSeries());
            Test("Series(379858)", await client.Series(379858));            
            Test("SeriesExtended(379858)", await client.SeriesExtended(379858));
            Test("SeriesEpisodes(379858, 'official')", await client.SeriesEpisodes(379858, "official"));
            Test("SeriesSeasonEpisodesTranslated(379858, 'official', 'eng')", await client.SeriesSeasonEpisodesTranslated(379858, "official", "eng"));
            Test("SeriesTranslation(379858, 'eng')", await client.SeriesTranslation(379858, "eng"));

            // Series Statuses
            Test("SeriesStatuses()", await client.SeriesStatuses());

            // Source Types
            Test("SourceTypes()", await client.SourceTypes());

            // Updates
            Test("Updates(type=series, action=update)",
                await client.Updates(new UpdatesOptionalParams { Type = "episodes", Action = "update", Since = DateTime.Now.AddDays(-30).ToUnixEpochTime() }));

            Console.WriteLine("Done.");
        }

        private static void Test(string tag, object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            Console.WriteLine();
            Console.WriteLine($"{tag} => {json}");
        }
    }

    public static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static int ToUnixEpochTime(this DateTime time)
        {
            return (int)(time - Epoch).TotalSeconds;
        }
    }

    public class AuthenticationData
    {
        public string ApiKey { get; set; }

        public string Pin { get; set; }
    }
}
