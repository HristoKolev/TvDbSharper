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
        private const string SWAGGER_URL = "https://thetvdb.github.io/v4-api/swagger.yml";

        private static void Main()
        {
            string yml = FetchSwaggerConfig().GetAwaiter().GetResult();

            File.WriteAllText("../../../../../test/GenerateDto/swagger.yml", yml);

            var swaggerConfig = SwaggerConfigParser.Parse(yml);

            DumpFullSwaggerConfig(swaggerConfig);

            DumpPaths(swaggerConfig);

            GenerateRequests(swaggerConfig);
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

        private static void GenerateRequests(SwaggerConfig swaggerConfig)
        {
            var ns = CodeBuilder.GetNamespace(swaggerConfig);

            string codeContent = CodeScripter.Script(ns);

            File.WriteAllText("../../../../../src/TvDbSharper/TvDbClient.Generated.cs", codeContent);
        }

        private static void DumpPaths(SwaggerConfig swaggerConfig)
        {
            var lines = new List<string>();

            foreach ((string path, var rest) in swaggerConfig.Paths)
            {
                if (rest.Count > 1)
                {
                    continue;
                }
                
                (string method, var requestInfo) = rest.Single();

                string result = $"{requestInfo.OperationId}(";

                if (requestInfo.Parameters != null)
                {
                    result += string.Join(", ", requestInfo.Parameters.Select(x => x.Name + ": " + x.Schema.Type));
                }

                var returnData = requestInfo.Responses["200"].Content["application/json"].Schema.Properties["data"];

                string returnType = "unknown";

                if (returnData.Reference != null)
                {
                    returnType = returnData.Reference.Split('/')[^1];
                }
                else if (returnData.Type == "array")
                {
                    returnType = returnData.Items.Reference.Split('/')[^1] + "[]";
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
            var response = await httpClient.GetAsync(SWAGGER_URL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
