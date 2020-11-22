namespace GenerateDto
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class SwaggerDataProvider
    {
        private static async Task<string> GetApiUrl()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://app.swaggerhub.com/apiproxy/registry/thetvdb/tvdb-api_v_4");
            string json = await response.Content.ReadAsStringAsync();
            string url = JToken.Parse(json)["apis"]![0]!["properties"]![0]!["url"]!.ToString();
            return url;
        }

        public static async Task<DtoModels> GetDtoModels()
        {
            string url = await GetApiUrl();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var model = JsonSerializer.Deserialize<DtoModels>(json, options);

            return model;
        }
    }

    public class DtoModels
    {
        public Dictionary<string, DefinitionModel> Definitions { get; set; }
    }

    public class DefinitionModel
    {
        public Dictionary<string, TypeModel> Properties { get; set; }
    }

    public class TypeModel
    {
        public string Type { get; set; }

        public string Format { get; set; }

        [JsonPropertyName("x-go-name")]
        public string XGoName { get; set; }

        [JsonPropertyName("$ref")]
        public string Reference { get; set; }

        public TypeModel Items { get; set; }
    }
}
