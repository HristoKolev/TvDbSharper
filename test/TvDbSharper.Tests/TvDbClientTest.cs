namespace TvDbSharper.Tests
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using NSubstitute;

    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;

    using Xunit;

    public class TvDbClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Add_Header_To_The_HttpClient()
        {
            var httpClient = CreateHttpClient();

            var client = CreateClient(httpClient);

            const string Language = "de";

            client.AcceptedLanguage = Language;

            Assert.True(httpClient.DefaultRequestHeaders.AcceptLanguage.Contains(new StringWithQualityHeaderValue(Language)));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Return_DefaultLanguage_If_Non_Is_Set()
        {
            var httpClient = CreateHttpClient();

            const string DefaultLanguage = "en";

            var client = CreateClient(httpClient);

            Assert.Equal(DefaultLanguage, client.AcceptedLanguage);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Return_The_Current_AcceptedLanguage()
        {
            var httpClient = CreateHttpClient();

            const string Language = "zh";

            httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(Language);

            var client = CreateClient(httpClient);

            Assert.Equal(Language, client.AcceptedLanguage);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_Empty_String()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.AcceptedLanguage = string.Empty);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_Null_Value()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentNullException>(() => client.AcceptedLanguage = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_White_Space()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.AcceptedLanguage = " \t ");
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthenticationClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Authentication);
            Assert.IsType<AuthenticationClient>(client.Authentication);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Sets_HttpClient_BaseAddress_To_The_Value()
        {
            var httpClient = CreateHttpClient();

            var client = CreateClient(httpClient);

            const string Value = "http://example.com";

            client.BaseUrl = Value;

            Assert.Equal(new Uri(Value), httpClient.BaseAddress);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Should_Return_The_Same_Value_That_Is_Passed_In()
        {
            var jsonCluent = CreateClient();

            const string Value = "http://example.com";

            jsonCluent.BaseUrl = Value;

            Assert.Equal(Value, jsonCluent.BaseUrl);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Empty_String()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.BaseUrl = string.Empty);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Null_Value()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentNullException>(() => client.BaseUrl = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_White_Space()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.BaseUrl = " \t ");
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_If_HttpClient_BaseUrl_Is_Null_Should_Set_To_Default()
        {
            var httpClient = CreateHttpClient();

            var client = CreateClient(httpClient);

            Assert.Equal("https://api.thetvdb.com", httpClient.BaseAddress?.AbsoluteUri?.TrimEnd('/'));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_If_HttpClient_Has_BaseUrl_Should_Not_Change_It()
        {
            var httpClient = CreateHttpClient();

            var uri = new Uri("http://example.com");

            httpClient.BaseAddress = uri;

            var client = CreateClient(httpClient);

            Assert.Equal(uri, httpClient.BaseAddress);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void EpisodesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Episodes);
            Assert.IsType<EpisodesClient>(client.Episodes);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void LanguagesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Languages);
            Assert.IsType<LanguagesClient>(client.Languages);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void SearchClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Search);
            Assert.IsType<SearchClient>(client.Search);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void SeriesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Series);
            Assert.IsType<SeriesClient>(client.Series);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void UpdatesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Updates);
            Assert.IsType<UpdatesClient>(client.Updates);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void UsersClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Users);
            Assert.IsType<UsersClient>(client.Users);
        }

        private static ITvDbClient CreateClient(HttpClient httpClient)
        {
            return new TvDbClient(httpClient);
        }

        private static ITvDbClient CreateClient()
        {
            return new TvDbClient();
        }

        private static HttpClient CreateHttpClient()
        {
            return Substitute.For<HttpClient>();
        }
    }
}