namespace TvDbSharper.Api.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Languages.Json;
    using TvDbSharper.RestClient.Json;

    public interface ILanguagesClient
    {
        Task<TvDbResponse<LanguageData[]>> GetAllAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<LanguageData>> GetAsync(int languageId, CancellationToken cancellationToken);
    }
}