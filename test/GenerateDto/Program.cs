namespace GenerateDto
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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

            DumpFullSwaggerConfig(swaggerConfig);

            DumpPaths(swaggerConfig);

            GenerateDto(swaggerConfig);
        }

        private static void DumpFullSwaggerConfig(SwaggerConfig swaggerConfig)
        {
            string json = JsonConvert.SerializeObject(
                swaggerConfig, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                });

            File.WriteAllText("../../../../../test/GenerateDto/swagger-dump.json", json);
        }

        private static void GenerateDto(SwaggerConfig swaggerConfig)
        {
            var namespaceModel = CodeBuilder.GetNamespace(swaggerConfig);

            string codeContent = CodeScripter.Script(namespaceModel);

            File.WriteAllText("../../../../../src/TvDbSharper/Dto.cs", codeContent);
        }

        private static void DumpPaths(SwaggerConfig swaggerConfig)
        {
            var lines = new List<string>();

            foreach ((string path, var rest) in swaggerConfig.Paths)
            {
                (string method, var requestInfo) = rest.Single();

                string result = $"{requestInfo.OperationId}(";

                if (requestInfo.Parameters != null)
                {
                    result += string.Join(", ", requestInfo.Parameters.Select(x => x.Name + ": " + x.Schema.Type));
                }

                string returnType = requestInfo.Responses["200"].Content["application/json"].Schema.Properties["data"].Reference;

                if (returnType != null)
                {
                    returnType = returnType.Split('/')[^1];
                }
                else
                {
                    returnType = "unknown";
                }

                result += $") => {returnType} | {method.ToUpper()} {path}";

                lines.Add(result);
            }
            
            lines.Sort();

            File.WriteAllText("../../../../../test/GenerateDto/swagger-paths.txt", string.Join("\n", lines));
        }

        private static async Task<string> FetchSwaggerConfig()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://thetvdb.github.io/v4-api/swagger.yml");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
