namespace TvDbSharper.Clients.Updates
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Updates.Json;

    public interface IUpdatesClient
    {
        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, CancellationToken cancellationToken);

        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken);

        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime);

        Task<TvDbResponse<Update[]>> GetAsync(DateTime fromTime, DateTime toTime);
    }
}