namespace GenerateDto
{
    using System.Collections.Generic;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;

    public static class SwaggerConfigParser
    {
        public static SwaggerConfig Parse(string yml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();

            return deserializer.Deserialize<SwaggerConfig>(yml);
        }
    }

    public class SwaggerConfig
    {
        [YamlMember(Alias = "openapi")]
        public string OpenApi { get; set; }

        public SwaggerConfigInfo Info { get; set; }

        public List<SecurityInfo> Security { get; set; }

        public Dictionary<string, Dictionary<string, RequestInfo>> Paths { get; set; }

        public List<SwaggerServer> Servers { get; set; }

        public SwaggerConfigComponents Components { get; set; }
    }

    public class SwaggerServer
    {
        public string Url { get; set; }
    }

    public class SecurityInfo
    {
        [YamlMember(Alias = "bearerAuth", ApplyNamingConventions = false)]
        public string[] BearerAuth { get; set; }
    }

    public class SwaggerConfigInfo
    {
        public string Description { get; set; }

        public string Title { get; set; }

        public string Version { get; set; }
    }

    public class SwaggerConfigComponents
    {
        // ReSharper disable once CollectionNeverUpdated.Global
        public Dictionary<string, SchemaModel> Schemas { get; set; }

        [YamlMember(Alias = "securitySchemes", ApplyNamingConventions = false)]
        public SwaggerSecurityScheme SecuritySchemes { get; set; }
    }

    public class SwaggerSecurityScheme
    {
        [YamlMember(Alias = "bearerAuth", ApplyNamingConventions = false)]
        public BearerAuthInfo BearerAuth { get; set; }
    }

    public class BearerAuthInfo
    {
        public string Type { get; set; }

        public string Scheme { get; set; }

        [YamlMember(Alias = "bearerFormat", ApplyNamingConventions = false)]
        public string BearerFormat { get; set; }
    }

    public class RequestInfo
    {
        public string Description { get; set; }

        public string Summary { get; set; }

        [YamlMember(Alias = "requestBody", ApplyNamingConventions = false)]
        public RequestBodyInfo RequestBody { get; set; }

        [YamlMember(Alias = "operationId", ApplyNamingConventions = false)]
        public string OperationId { get; set; }

        public ParameterInfo[] Parameters { get; set; }

        public Dictionary<string, ResponseInfo> Responses { get; set; }

        public string[] Tags { get; set; }
    }

    public class RequestBodyInfo
    {
        public Dictionary<string, ContentInfo> Content { get; set; }

        public bool Required { get; set; }
    }

    public class ResponseInfo
    {
        public string Description { get; set; }

        public Dictionary<string, ContentInfo> Content { get; set; }
    }

    public class ContentInfo
    {
        public SchemaModel Schema { get; set; }
    }

    public class ParameterInfo
    {
        public string Description { get; set; }

        public string In { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public SchemaModel Schema { get; set; }

        public Dictionary<string, ParameterExample> Examples { get; set; }
    }

    public class ParameterExample
    {
        public string Value { get; set; }
    }

    public class SchemaModel
    {
        public string Description { get; set; }

        public string[] Required { get; set; }

        // ReSharper disable once CollectionNeverUpdated.Global
        public Dictionary<string, TypeModel> Properties { get; set; }

        public string Type { get; set; }

        public string Default { get; set; }

        public string[] Enum { get; set; }

        public string Example { get; set; }

        [YamlMember(Alias = "x-go-package", ApplyNamingConventions = false)]
        public string GoPackage { get; set; }
    }

    public class TypeModel
    {
        public string Format { get; set; }

        [YamlMember(Alias = "x-go-name", ApplyNamingConventions = false)]
        public string GoName { get; set; }

        [YamlMember(Alias = "$ref")]
        public string Reference { get; set; }

        public TypeModel Items { get; set; }

        // ReSharper disable once CollectionNeverUpdated.Global
        public Dictionary<string, TypeModel> Properties { get; set; }

        public string Type { get; set; }
    }
}
