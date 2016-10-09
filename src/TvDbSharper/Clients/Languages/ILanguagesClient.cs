namespace TvDbSharper.Clients.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Languages.Json;

    public interface ILanguagesClient
    {
        Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<Language[]>> GetAllAsync();

        Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken);

        Task<TvDbResponse<Language>> GetAsync(int languageId);
    }
}