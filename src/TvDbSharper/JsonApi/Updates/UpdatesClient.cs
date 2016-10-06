namespace TvDbSharper.JsonApi.Updates
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Updates.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class UpdatesClient : BaseClient, IUpdatesClient
    {
        public UpdatesClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, CancellationToken cancellationToken)
        {
            string requestUri = $"/updated/query?fromTime={fromTime.ToUnixEpochTime()}";

            return await this.GetAsync<Update[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken)
        {
            string requestUri = $"/updated/query?fromTime={fromTime.ToUnixEpochTime()}&toTime={toTime.ToUnixEpochTime()}";

            return await this.GetAsync<Update[]>(requestUri, cancellationToken);
        }
    }
}