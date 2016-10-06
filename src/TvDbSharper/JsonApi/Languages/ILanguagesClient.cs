namespace TvDbSharper.JsonApi.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Languages.Json;
    using TvDbSharper.RestClient.Json;

    public interface ILanguagesClient
    {
        Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken);
    }
}