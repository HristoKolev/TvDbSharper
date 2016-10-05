namespace TvDbSharper.Api.Updates
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Updates.Json;
    using TvDbSharper.RestClient.Json;

    public interface IUpdatesClient
    {
        Task<TvDbResponse<UpdateData[]>> GetAsync(DateTime fromTime, CancellationToken cancellationToken);

        Task<TvDbResponse<UpdateData[]>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken);
    }
}