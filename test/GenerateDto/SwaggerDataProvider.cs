namespace GenerateDto
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;

    public static class SwaggerDataProvider
    {
        public static async Task<SwaggerConfig> GetDtoModels()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://thetvdb.github.io/v4-api/swagger.yml");
            string ymlContent = await response.Content.ReadAsStringAsync();

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance) // see height_in_inches in sample yml
                .IgnoreUnmatchedProperties()
                .Build();

            return deserializer.Deserialize<SwaggerConfig>(ymlContent);
        }
    }

    public class SwaggerConfig
    {
        public SwaggerConfigComponents Components { get; set; }
    }

    public class SwaggerConfigComponents
    {
        public Dictionary<string, SchemaModel> Schemas { get; set; }
    }

    public class SchemaModel
    {
        public string Description { get; set; }

        public Dictionary<string, TypeModel> Properties = new();
    }

    public class TypeModel
    {
        public string Type { get; set; }

        public string Format { get; set; }

        [YamlMember(Alias = "x-go-name")]
        public string GoName { get; set; }

        [YamlMember(Alias = "$ref")]
        public string Reference { get; set; }

        public TypeModel Items { get; set; }
    }
}
