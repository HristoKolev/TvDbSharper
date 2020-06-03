namespace TvDbSharper.Tests
{
    using System;
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Data;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class LanguagesClientTest
    {
        [Fact]
        public Task GetAllAsync_IgnoresLanguagesWithNullValues()
        {
            ApiResponse response = new ApiResponse
            {
                Body =
                "{\"data\":[" +
                    "{\"id\":null,\"abbreviation\":\"yue\",\"name\":\"广东话\",\"englishName\":\"Chinese - Cantonese\"}," +
                    "{\"id\":101,\"abbreviation\":\"aa\",\"name\":\"Afaraf\",\"englishName\":\"Afar\"}" +
                "]}",
                StatusCode = 200
            };
            TvDbResponse<Language[]> originalResponse = new Parser().Parse<TvDbResponse<Language[]>>(response, ErrorMessages.Languages.GetAllAsync);
            TvDbResponse<Language[]> expectedResponse = new TvDbResponse<Language[]>();
            expectedResponse.Data = new Language[2];
            Array.Copy(originalResponse.Data, 0, expectedResponse.Data, 0, originalResponse.Data.Length);
            return CreateClient(response)
                .WithErrorMap(ErrorMessages.Languages.GetAllAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAllAsync(token))
                .ShouldRequest("GET", "/languages")
                .AssertReturnValue((actualResponse) =>
                {
                    Assert.Equal(expectedResponse, actualResponse);
                })
                .SetResultObject(expectedResponse).RunAsync();
        }



        [Fact]
        // ReSharper disable once InconsistentNaming
        public Task GetAllAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Languages.GetAllAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAllAsync(token))
                .ShouldRequest("GET", "/languages")
                .SetResultObject(new TvDbResponse<Language[]>())
                .RunAsync();
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public Task GetAllAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Languages.GetAllAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAllAsync())
                .ShouldRequest("GET", "/languages")
                .WithNoCancellationToken()
                .SetResultObject(new TvDbResponse<Language[]>())
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]
        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Makes_The_Right_Request(int languageId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Languages.GetAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAsync(languageId, token))
                .ShouldRequest("GET", $"/languages/{languageId}")
                .SetResultObject(new TvDbResponse<Language>())
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(IntegerData))]
        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_CT_Makes_The_Right_Request(int languageId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Languages.GetAsync)
                .WhenCallingAMethod((impl, token) => impl.GetAsync(languageId))
                .ShouldRequest("GET", $"/languages/{languageId}")
                .SetResultObject(new TvDbResponse<Language>())
                .WithNoCancellationToken()
                .RunAsync();
        }

        private static ApiTest<LanguagesClient> CreateClient()
        {
            return CreateClient(new ApiResponse());
        }
        private static ApiTest<LanguagesClient> CreateClient(ApiResponse response)
        {
            return new ApiTest<LanguagesClient>()
                .WithConstructor((client, parser) => new LanguagesClient(client, parser))
                .SetApiResponse(response);
        }
    }
}