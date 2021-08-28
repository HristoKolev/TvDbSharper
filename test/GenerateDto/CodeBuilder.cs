namespace GenerateDto
{
    using System;
    using System.Collections.Generic;

    public class CodeBuilder
    {
        public static NamespaceModel GetNamespace(SwaggerConfig models)
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

            foreach ((string modelName, var model) in models.Components.Schemas)
            {
                var classModel = new ClassModel
                {
                    ClassName = modelName + "Dto",
                    Properties = new List<PropertyModel>(),
                };

                foreach ((string propertyName, var propertyType) in model.Properties)
                {
                    string pascalCaseName = char.ToUpper(propertyName[0]) + propertyName.Remove(0, 1);

                    classModel.Properties.Add(new PropertyModel
                    {
                        PropertyName = pascalCaseName,
                        PropertyType = ScriptComplexType(propertyName, propertyType),
                        PropertyAttributes = new List<string>
                        {
                            $"[JsonProperty(\"{propertyName}\")]",
                        },
                    });
                }

                ns.Classes.Add(classModel);
            }

            return ns;
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
                    if (fieldName == "id")
                    {
                        return "long";
                    }

                    return "int";
                }
                case "integer":
                {
                    if (fieldName == "id")
                    {
                        return "long";
                    }

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
