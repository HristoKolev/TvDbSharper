namespace GenerateDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CodeBuilder
    {
        public static NamespaceModel GetNamespace(SwaggerConfig swaggerConfig)
        {
            var ns = new NamespaceModel
            {
                NamespaceName = "TvDbSharper",
                Usings = new List<string>
                {
                    "Newtonsoft.Json",
                },
                Classes = new List<ClassModel>(),
            };

            foreach ((string modelName, var model) in swaggerConfig.Components.Schemas)
            {
                var classModel = new ClassModel
                {
                    ClassName = modelName + "Dto",
                    Properties = new List<PropertyModel>(),
                };

                if (model.Properties != null)
                {
                    foreach ((string fieldName, var propertyType) in model.Properties)
                    {
                        string propertyName = GetPropertyName(fieldName);

                        classModel.Properties.Add(new PropertyModel
                        {
                            PropertyName = propertyName,
                            PropertyType = ScriptComplexType(fieldName, propertyType),
                            PropertyAttributes = new List<string>
                            {
                                $"[JsonProperty(\"{fieldName}\")]",
                            },
                        });
                    }
                }

                ns.Classes.Add(classModel);
            }

            foreach ((string _, var methodMap) in swaggerConfig.Paths)
            {
                foreach ((string method, var requestInfo) in methodMap)
                {
                    if (method != "get")
                    {
                        continue;
                    }

                    var classModel = new ClassModel
                    {
                        ClassName = char.ToUpper(requestInfo.OperationId[0]) + requestInfo.OperationId.Remove(0, 1) + "Response",
                        Properties = new List<PropertyModel>(),
                    };

                    var properties = requestInfo.Responses["200"].Content["application/json"].Schema.Properties;

                    foreach ((string fieldName, var propertyType) in properties)
                    {
                        string propertyName = GetPropertyName(fieldName);

                        if (propertyType.Type == "object")
                        {
                            // Create a new class for the data property.
                            string dataClassName = classModel.ClassName + "Data";
                            var dataClassProperties = propertyType.Properties;
                            var dataClass = CreateDataClass(dataClassName, dataClassProperties);
                            ns.Classes.Add(dataClass);

                            classModel.Properties.Add(new PropertyModel
                            {
                                PropertyName = propertyName,
                                PropertyType = dataClass.ClassName,
                                PropertyAttributes = new List<string>
                                {
                                    $"[JsonProperty(\"{fieldName}\")]",
                                },
                            });
                        }
                        else
                        {
                            classModel.Properties.Add(new PropertyModel
                            {
                                PropertyName = propertyName,
                                PropertyType = ScriptComplexType(fieldName, propertyType),
                                PropertyAttributes = new List<string>
                                {
                                    $"[JsonProperty(\"{fieldName}\")]",
                                },
                            });
                        }
                    }

                    // Ignore this for now. If the abstraction that replaces it fails then used it.
                    // ns.Classes.Add(classModel);
                }
            }

            return ns;
        }

        private static ClassModel CreateDataClass(string className, Dictionary<string, TypeModel> dataClassProperties)
        {
            var classModel = new ClassModel
            {
                ClassName = className,
                Properties = new List<PropertyModel>(),
            };

            foreach ((string fieldName, var propertyType) in dataClassProperties)
            {
                string propertyName = GetPropertyName(fieldName);

                classModel.Properties.Add(new PropertyModel
                {
                    PropertyName = propertyName,
                    PropertyType = ScriptComplexType(fieldName, propertyType),
                    PropertyAttributes = new List<string>
                    {
                        $"[JsonProperty(\"{fieldName}\")]",
                    },
                });
            }

            return classModel;
        }

        private static string GetPropertyName(string fieldName)
        {
            string name = char.ToUpper(fieldName[0]) + fieldName.Remove(0, 1);

            var parts = name.Split('_');

            if (parts.Length == 1)
            {
                return name;
            }

            name = parts[0];

            foreach (string part in parts.Skip(1))
            {
                name += char.ToUpper(part[0]) + part.Remove(0, 1);
            }

            return name;
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

            if (typeModel.Items != null)
            {
                return ScriptComplexType(fieldName, typeModel.Items) + "[]";
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
            return format switch
            {
                "int64" => "long",
                "double" => "double",
                _ => throw new ApplicationException($"Unknown format `{format}`."),
            };
        }

        private static string ScriptType(string fieldName, TypeModel typeModel)
        {
            return typeModel.Type switch
            {
                "string" => "string",
                "number" => fieldName == "id" ? "long" : "int",
                "integer" => fieldName == "id" ? "long" : "int",
                "boolean" => "bool",
                "array" => ScriptComplexType(fieldName, typeModel.Items) + "[]",
                _ => throw new ApplicationException($"Unknown type `{typeModel.Type}`."),
            };
        }
    }

    public class NamespaceModel
    {
        public string NamespaceName { get; set; }

        public List<string> Usings { get; set; }

        public List<ClassModel> Classes { get; set; }
    }

    public class ClassModel
    {
        public string ClassName { get; set; }

        public List<PropertyModel> Properties { get; set; }
    }

    public class PropertyModel
    {
        public string PropertyName { get; set; }

        public string PropertyType { get; set; }

        public List<string> PropertyAttributes { get; set; }
    }
}
