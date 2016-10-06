namespace TvDbSharper.Api.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Languages.Json;
    using TvDbSharper.RestClient.Json;

    public interface ILanguagesClient
    {
        Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken);
    }
}