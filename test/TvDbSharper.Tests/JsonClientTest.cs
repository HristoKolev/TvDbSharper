namespace TvDbSharper.Tests
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using NSubstitute;

    using TvDbSharper.JsonClient;

    using Xunit;

    public class JsonClientTest
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
        public void Constructor_Sets_HttpClient_DefaultRequestHeaders_Accept_To_Json()
        {
            var httpClient = Substitute.For<HttpClient>();

            var jsonClient = new JsonClient(httpClient);

            Assert.True(httpClient.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")));
        }
    }
}