namespace GenerateDto
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class Program
    {
        private static void Main()
        {
            string yml = FetchSwaggerConfig().GetAwaiter().GetResult();

            File.WriteAllText("../../../../../test/GenerateDto/swagger.yml", yml);

            var swaggerConfig = SwaggerConfigParser.Parse(yml);

            File.WriteAllText("../../../../../test/GenerateDto/swagger-dump.json", JsonConvert.SerializeObject(
                swaggerConfig, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                }));

            var namespaceModel = CodeBuilder.GetNamespace(swaggerConfig);
            string codeContent = CodeScripter.Script(namespaceModel);

            File.WriteAllText("../../../../../src/TvDbSharper/Dto.cs", codeContent);
        }

        private static async Task<string> FetchSwaggerConfig()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://thetvdb.github.io/v4-api/swagger.yml");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
