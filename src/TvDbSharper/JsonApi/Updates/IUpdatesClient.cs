namespace TvDbSharper.JsonApi.Updates
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Updates.Json;
    using TvDbSharper.RestClient.Json;

    public interface IUpdatesClient
    {
        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, CancellationToken cancellationToken);

        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken);
    }
}