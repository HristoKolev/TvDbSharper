namespace TvDbSharper.Tests
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using NSubstitute;

    using TvDbSharper.JsonClient;

    using Xunit;

    public class HttpJsonClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthorizationHeader_Shold_Pass_Its_Value_To_HttpClient_HttpClient_DefaultRequestHeaders_Authorization()
        {
            var httpClient = Substitute.For<HttpClient>();

            var value = new AuthenticationHeaderValue("Key", "Value");

            var jsonClient = new JsonClient(httpClient)
            {
                AuthorizationHeader = value
            };

            Assert.Equal(value, httpClient.DefaultRequestHeaders.Authorization);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthorizationHeader_Should_Return_The_Same_Value_That_Is_Passed_In()
        {
            var httpClient = Substitute.For<HttpClient>();

            var value = new AuthenticationHeaderValue("Key", "Value");

            var jsonClient = new JsonClient(httpClient);

            jsonClient.AuthorizationHeader = value;

            Assert.Equal(value, jsonClient.AuthorizationHeader);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthorizationHeader_Throws_When_Passed_Null_Value()
        {
            var client = new JsonClient(Substitute.For<HttpClient>());

            Assert.Throws<ArgumentNullException>(() => client.AuthorizationHeader = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Sets_HttpClient_BaseAddress_To_The_Value()
        {
            var httpClient = Substitute.For<HttpClient>();

            var jsonCluent = new JsonClient(httpClient);

            const string Value = "http://example.com";

            jsonCluent.BaseUrl = Value;

            Assert.Equal(new Uri(Value), httpClient.BaseAddress);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Should_Return_The_Same_Value_That_Is_Passed_In()
        {
            var jsonCluent = new JsonClient(Substitute.For<HttpClient>());

            const string Value = "http://example.com";

            jsonCluent.BaseUrl = Value;

            Assert.Equal(Value, jsonCluent.BaseUrl);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Empty_String()
        {
            var client = new JsonClient(Substitute.For<HttpClient>());

            Assert.Throws<ArgumentException>(() => client.BaseUrl = string.Empty);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Null_Value()
        {
            var client = new JsonClient(Substitute.For<HttpClient>());

            Assert.Throws<ArgumentNullException>(() => client.BaseUrl = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_White_Space()
        {
            var client = new JsonClient(Substitute.For<HttpClient>());

            Assert.Throws<ArgumentException>(() => client.BaseUrl = " \t ");
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_If_HttpClient_BaseUrl_Is_Null_Should_Set_To_Default()
        {
            var httpClient = Substitute.For<HttpClient>();

            var client = new JsonClient(httpClient);

            Assert.Equal("https://api.thetvdb.com", httpClient.BaseAddress?.AbsoluteUri?.TrimEnd('/'));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_If_HttpClient_Has_BaseUrl_Should_Not_Change_It()
        {
            var httpClient = Substitute.For<HttpClient>();

            var uri = new Uri("http://example.com");

            httpClient.BaseAddress = uri;

            var client = new JsonClient(httpClient);

            Assert.Equal(uri, httpClient.BaseAddress);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_Sets_HttpClient_DefaultRequestHeaders_Accept_To_Json()
        {
            var httpClient = Substitute.For<HttpClient>();

            var jsonClient = new JsonClient(httpClient);

            Assert.True(httpClient.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")));
        }
    }
}