namespace GenerateDto
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        private static void Main()
        {
            string url = GetApiUrl().GetAwaiter().GetResult();

            var model = GetDtoModels(url).GetAwaiter().GetResult();

            var sb = new StringBuilder();

            sb.AppendLine("namespace TvDbSharper");

            sb.AppendLine("{");
            sb.AppendLine("    using Newtonsoft.Json;");
            sb.AppendLine();

            bool first = true;

            foreach (var kvp in model)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.AppendLine();
                }

                sb.Append(ScriptDto(kvp));
            }

            sb.AppendLine("}");

            File.WriteAllText("../../../../../src/TvDbSharper/Dto.cs", sb.ToString());
        }

        private static string ScriptDto(KeyValuePair<string, DefinitionModel> kvp)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"    public class {kvp.Key}Dto");
            sb.AppendLine("    {");

            bool first = true;

            foreach ((string fieldName, TypeModel type) in kvp.Value.Properties)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.AppendLine();
                }

                string propName = char.ToUpper(fieldName[0]) + fieldName.Remove(0, 1);

                sb.AppendLine($"        [JsonProperty(\"{fieldName}\")]");
                sb.AppendLine($"        public {ScriptComplexType(fieldName, type)} {propName} {{ get; set; }}");
            }

            sb.AppendLine("    }");

            return sb.ToString();
        }

        private static string ScriptComplexType(string fieldName, TypeModel typeModel)
        {
            if (typeModel.Reference != null)
            {
                return GetReferenceName(typeModel.Reference);
            }

            if (typeModel.Format != null)
            {
                return ScriptFormat(typeModel.Format);
            }

            if (typeModel.Type != null)
            {
                return ScriptType(fieldName, typeModel);
            }

            // this is bullshit
            if (fieldName == "name")
            {
                return "string";
            }

            throw new ApplicationException("Cannot find type information.");
        }

        private static string GetReferenceName(string reference)
        {
            return reference.Split('/')[^1] + "Dto";
        }

        private static string ScriptFormat(string format)
        {
            switch (format)
            {
                case "int64":
                {
                    return "long";
                }
                case "double":
                {
                    return "double";
                }
                default:
                {
                    throw new ApplicationException($"Unknown format `{format}`.");
                }
            }
        }

        private static string ScriptType(string fieldName, TypeModel typeModel)
        {
            switch (typeModel.Type)
            {
                case "string":
                {
                    return "string";
                }
                case "number":
                {
                    return "int";
                }
                case "boolean":
                {
                    return "bool";
                }
                case "array":
                {
                    return ScriptComplexType(fieldName, typeModel.Items) + "[]";
                }
                default:
                {
                    throw new ApplicationException($"Unknown type `{typeModel.Type}`.");
                }
            }
        }

        private static async Task<string> GetApiUrl()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://app.swaggerhub.com/apiproxy/registry/thetvdb/tvdb-api_v_4");
            string json = await response.Content.ReadAsStringAsync();
            string url = JToken.Parse(json)["apis"]![0]!["properties"]![0]!["url"]!.ToString();
            return url;
        }

        private static async Task<Dictionary<string, DefinitionModel>> GetDtoModels(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<DtoModels>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return model.Definitions;
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
