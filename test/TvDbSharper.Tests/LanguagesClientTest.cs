namespace TvDbSharper.Tests
{
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
            return new ApiTest<LanguagesClient>()
                .WithConstructor((client, parser) => new LanguagesClient(client, parser))
                .SetApiResponse(new ApiResponse());
        }
    }
}