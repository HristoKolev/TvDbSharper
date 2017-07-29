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

    public class UpdatesClientTest
    {
        [Theory]
        [ClassData(typeof(UpdatesData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Makes_The_Right_Request(string fromDate, string toDate, string actualFromDate, string actualToDate)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetAsync(DateTime.Parse(fromDate), DateTime.Parse(toDate), token))
                .ShouldRequest("GET", $"/updated/query?fromTime={actualFromDate}&toTime={actualToDate}")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(UpdatesData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Without_CT_Makes_The_Right_Request(string fromDate, string toDate, string actualFromDate, string actualToDate)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetAsync(DateTime.Parse(fromDate), DateTime.Parse(toDate)))
                .ShouldRequest("GET", $"/updated/query?fromTime={actualFromDate}&toTime={actualToDate}")
                .WithNoCancellationToken()
                .RunAsync();
        }


        [Theory]
        [ClassData(typeof(UpdatesData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Without_ToDate_Makes_The_Right_Request(string fromDate, string toDate, string actualFromDate, string actualToDate)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetAsync(DateTime.Parse(fromDate), token))
                .ShouldRequest("GET", $"/updated/query?fromTime={actualFromDate}")
                .RunAsync();
        }

        [Theory]
        [ClassData(typeof(UpdatesData))]

        // ReSharper disable once InconsistentNaming
        public Task SearchSeriesAsync_Without_ToDate_Without_CT_Makes_The_Right_Request(string fromDate, string toDate, string actualFromDate, string actualToDate)
        {
            return CreateClient()
                .WhenCallingAMethod((impl, token) => impl.GetAsync(DateTime.Parse(fromDate)))
                .ShouldRequest("GET", $"/updated/query?fromTime={actualFromDate}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        private static ApiTest<UpdatesClient> CreateClient()
        {
            return new ApiTest<UpdatesClient>()
                .WithConstructor((client, parser) => new UpdatesClient(client, parser))
                .WithErrorMap(ErrorMessages.Updates.GetAsync)
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new TvDbResponse<Update[]>());
        }
    }
}