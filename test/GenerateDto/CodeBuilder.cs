namespace GenerateDto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CodeBuilder
    {
        private static readonly Dictionary<string, string> MethodNameMap = new()
        {
            { "getAllArtworkStatuses", "ArtworkStatuses" },
            { "getAllArtworkTypes", "ArtworkTypes" },
            { "getAllAwards", "Awards" },
            { "getAllCompanies", "Companies" },
            { "getAllContentRatings", "ContentRatings" },
            { "getAllCountries", "Countries" },
            { "getAllGenders", "Genders" },
            { "getAllGenres", "Genres" },
            { "getAllLanguages", "Languages" },
            { "getAllLists", "Lists" },
            { "getAllMovie", "Movies" },
            { "getAllMovieStatuses", "MovieStatuses" },
            { "getAllPeopleTypes", "PeopleTypes" },
            { "getAllSeasons", "Seasons" },
            { "getAllSeries", "AllSeries" },
            { "getAllSeriesStatuses", "SeriesStatuses" },
            { "getAllSourceTypes", "SourceTypes" },
            { "getArtworkBase", "Artwork" },
            { "getArtworkExtended", "ArtworkExtended" },
            { "getArtworkTranslation", "ArtworkTranslation" },
            { "getAward", "Award" },
            { "getAwardCategory", "AwardCategory" },
            { "getAwardCategoryExtended", "AwardCategoryExtended" },
            { "getAwardExtended", "AwardExtended" },
            { "getCharacterBase", "Character" },
            { "getCompany", "Company" },
            { "getCompanyTypes", "CompanyTypes" },
            { "getEntityTypes", "EntityTypes" },
            { "getEpisodeBase", "Episode" },
            { "getEpisodeExtended", "EpisodeExtended" },
            { "getEpisodeTranslation", "EpisodeTranslation" },
            { "getGenreBase", "Genre" },
            { "getList", "List" },
            { "getListExtended", "ListExtended" },
            { "getListTranslation", "ListTranslation" },
            { "getMovieBase", "Movie" },
            { "getMovieExtended", "MovieExtended" },
            { "getMovieTranslation", "MovieTranslation" },
            { "getPeopleBase", "People" },
            { "getPeopleExtended", "PeopleExtended" },
            { "getPeopleTranslation", "PeopleTranslation" },
            { "getSearchResults", "Search" },
            { "getSeasonBase", "Season" },
            { "getSeasonExtended", "SeasonExtended" },
            { "getSeasonTranslation", "SeasonTranslation" },
            { "getSeasonTypes", "SeasonTypes" },
            { "getSeriesBase", "Series" },
            { "getSeriesExtended", "SeriesExtended" },
            { "getSeriesEpisodes", "SeriesEpisodes" },
            { "getSeriesSeasonEpisodesTranslated", "SeriesSeasonEpisodesTranslated" },
            { "getSeriesTranslation", "SeriesTranslation" },
            { "updates", "Updates" },
        };

        public static NamespaceModel GetNamespace(SwaggerConfig swaggerConfig)
        {
            var tvdbClient = new ClassModel
            {
                ClassName = "TvDbClient",
                Partial = true,
            };

            var ns = new NamespaceModel
            {
                NamespaceName = "TvDbSharper",
                TopLevelComments = new List<string>
                {
                    "// ReSharper disable HeapView.BoxingAllocation",
                    "// ReSharper disable MemberCanBePrivate.Global",
                    "// ReSharper disable UnusedMember.Global",
                    "// ReSharper disable RedundantStringInterpolation",
                },
                Usings = new List<string>
                {
                    "System.Threading",
                    "System.Threading.Tasks",
                    "Newtonsoft.Json",
                },
                Classes = new List<ClassModel>
                {
                    tvdbClient,
                },
            };

            // Generate client methods
            foreach ((string path, var rest) in swaggerConfig.Paths)
            {
                if (path == "/login")
                {
                    continue;
                }

                var requestInfo = rest.Single().Value;

                string url = path.TrimStart('/');

                var pathParameters = (requestInfo.Parameters ?? Array.Empty<ParameterInfo>()).Where(x => x.In == "path").ToList();

                var methodArgumentsMap = pathParameters.ToDictionary(x => x.Name, x => new MethodArgument
                {
                    Type = GetParameterType(x),
                    Name = KebabToPascal(x.Name),
                });

                foreach ((string key, var methodArgument) in methodArgumentsMap)
                {
                    url = url.Replace(key, methodArgument.Name);
                }

                var returnType = GetMethodReturnType(requestInfo);

                string methodName = MethodNameMap[requestInfo.OperationId];

                // With CT
                tvdbClient.Methods.Add(new MethodModel
                {
                    MethodName = methodName,
                    Arguments = methodArgumentsMap.Values
                        .Concat(new[] { new MethodArgument { Type = "CancellationToken", Name = "cancellationToken" } }).ToList(),
                    ReturnType = $"Task<{returnType}>",
                    Body = $"return this.GenericRequest<{returnType}>($\"{url}\", null, cancellationToken);",
                });

                // Without CT
                tvdbClient.Methods.Add(new MethodModel
                {
                    MethodName = methodName,
                    Arguments = methodArgumentsMap.Values.ToList(),
                    ReturnType = $"Task<{returnType}>",
                    Body =
                        $"return this.{methodName}({string.Join(", ", methodArgumentsMap.Values.Select(x => x.Name).Concat(new[] { "CancellationToken.None" }))});",
                });

                var queryParameters = (requestInfo.Parameters ?? Array.Empty<ParameterInfo>()).Where(x => x.In == "query").ToList();

                if (queryParameters.Any())
                {
                    string optionalParamsClassName = methodName + "OptionalParams";

                    var optionalParamsClass = new ClassModel
                    {
                        ClassName = optionalParamsClassName,
                        Properties = queryParameters.Select(x => new PropertyModel
                        {
                            PropertyName = CamelCase(x.Name),
                            PropertyType = GetQueryParameterType(x),
                            PropertyAttributes = new List<string>
                            {
                                $"[QueryParameter(\"{x.Name}\")]",
                            },
                        }).ToList(),
                    };

                    ns.Classes.Add(optionalParamsClass);

                    // With optional parameters and CT
                    tvdbClient.Methods.Add(new MethodModel
                    {
                        MethodName = methodName,
                        Arguments = methodArgumentsMap.Values
                            .Concat(new[]
                            {
                                new MethodArgument { Type = optionalParamsClassName, Name = "optionalParameters" },
                                new MethodArgument { Type = "CancellationToken", Name = "cancellationToken" },
                            }).ToList(),
                        ReturnType = $"Task<{returnType}>",
                        Body = $"return this.GenericRequest<{returnType}>($\"{url}\", optionalParameters, cancellationToken);",
                    });

                    // With optional parameters and without CT
                    tvdbClient.Methods.Add(new MethodModel
                    {
                        MethodName = methodName,
                        Arguments = methodArgumentsMap.Values.Concat(new[]
                        {
                            new MethodArgument { Type = optionalParamsClassName, Name = "optionalParameters" },
                        }).ToList(),
                        ReturnType = $"Task<{returnType}>",
                        Body =
                            $"return this.{methodName}({string.Join(", ", methodArgumentsMap.Values.Select(x => x.Name).Concat(new[] { "optionalParameters", "CancellationToken.None" }))});",
                    });
                }
            }

            // Generate Dto classes
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
                            FieldName = fieldName,
                            PropertyName = propertyName,
                            PropertyType = GetComplexType(fieldName, propertyType),
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
                                FieldName = fieldName,
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
                                FieldName = fieldName,
                                PropertyName = propertyName,
                                PropertyType = GetComplexType(fieldName, propertyType),
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

            ApplyDtoPropertyOverrides(ns);

            return ns;
        }

        private static string GetQueryParameterType(ParameterInfo parameterInfo)
        {
            string type = GetParameterType(parameterInfo);

            return type switch
            {
                "int" => "int?",
                _ => type,
            };
        }

        private static string GetParameterType(ParameterInfo parameterInfo)
        {
            return parameterInfo.Schema.Type switch
            {
                "integer" => "int",
                "number" => "int",
                _ => parameterInfo.Schema.Type,
            };
        }

        private static string GetMethodReturnType(RequestInfo requestInfo)
        {
            if (requestInfo.OperationId == "getSeriesEpisodes")
            {
                return "GetSeriesEpisodesResponseData";
            }

            if (requestInfo.OperationId == "getSeriesSeasonEpisodesTranslated")
            {
                return "GetSeriesSeasonEpisodesTranslatedResponseData";
            }

            var returnData = requestInfo.Responses["200"].Content["application/json"].Schema.Properties["data"];
            string returnType = "unknown";
            if (returnData.Reference != null)
            {
                returnType = returnData.Reference.Split('/')[^1] + "Dto";
            }
            else if (returnData.Type == "array")
            {
                returnType = returnData.Items.Reference.Split('/')[^1] + "Dto[]";
            }

            return returnType;
        }

        private static string CamelCase(string name)
        {
            char[] array = name.ToCharArray();

            array[0] = char.ToUpper(array[0]);

            return new string(array);
        }

        private static string KebabToPascal(string name)
        {
            var parts = name.Split('-').Select((x, i) =>
            {
                if (i == 0)
                {
                    return x;
                }

                return x[0].ToString().ToUpper() + x[1..];
            });

            return string.Join("", parts);
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
                    FieldName = fieldName,
                    PropertyName = propertyName,
                    PropertyType = GetComplexType(fieldName, propertyType),
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

        private static string GetComplexType(string fieldName, TypeModel typeModel)
        {
            if (typeModel.Reference != null)
            {
                return GetReferenceName(typeModel.Reference);
            }

            if (typeModel.Format != null)
            {
                return GetFormat(typeModel.Format);
            }

            if (typeModel.Type != null)
            {
                return GetType(fieldName, typeModel);
            }

            if (typeModel.Items != null)
            {
                return GetComplexType(fieldName, typeModel.Items) + "[]";
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

        private static string GetFormat(string format)
        {
            return format switch
            {
                "int64" => "long",
                "double" => "double",
                _ => throw new ApplicationException($"Unknown format `{format}`."),
            };
        }

        private static string GetType(string fieldName, TypeModel typeModel)
        {
            return typeModel.Type switch
            {
                "string" => "string",
                "number" => fieldName == "id" ? "long" : "int",
                "integer" => fieldName == "id" ? "long" : "int",
                "boolean" => "bool",
                "array" => GetComplexType(fieldName, typeModel.Items) + "[]",
                _ => throw new ApplicationException($"Unknown type `{typeModel.Type}`."),
            };
        }

        private static void ApplyDtoPropertyOverrides(NamespaceModel namespaceModel)
        {
            var propertyOverrides = new List<PropertyOverrideModel>
            {
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "peopleId",
                    OverrideType = "int?",
                },
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "seasonId",
                    OverrideType = "int?",
                },
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "episodeId",
                    OverrideType = "int?",
                },
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "seriesPeopleId",
                    OverrideType = "int?",
                },
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "networkId",
                    OverrideType = "int?",
                },
                new()
                {
                    MatchClassName = "ArtworkExtendedRecordDto",
                    MatchFieldName = "movieId",
                    OverrideType = "int?",
                },
            };

            var extraProperties = new Dictionary<string, List<PropertyModel>>
            {
                {
                    "ArtworkExtendedRecordDto", new List<PropertyModel>
                    {
                        new()
                        {
                            FieldName = "status",
                            PropertyName = "Status",
                            PropertyType = "object",
                            PropertyAttributes = new List<string>
                            {
                                "[JsonIgnore]",
                            },
                        },
                        new()
                        {
                            FieldName = "tagOptions",
                            PropertyName = "TagOptions",
                            PropertyType = "object",
                            PropertyAttributes = new List<string>
                            {
                                "[JsonIgnore]",
                            },
                        },
                    }
                },
            };

            foreach (var classModel in namespaceModel.Classes)
            {
                if (extraProperties.ContainsKey(classModel.ClassName))
                {
                    classModel.Properties.AddRange(extraProperties[classModel.ClassName]);
                }

                foreach (var modelProperty in classModel.Properties)
                {
                    foreach (var overrideModel in propertyOverrides)
                    {
                        if (classModel.ClassName == overrideModel.MatchClassName && modelProperty.FieldName == overrideModel.MatchFieldName)
                        {
                            if (overrideModel.OverrideType != null)
                            {
                                modelProperty.PropertyType = overrideModel.OverrideType;
                            }

                            if (overrideModel.OverridePropertyName != null)
                            {
                                modelProperty.PropertyName = overrideModel.OverridePropertyName;
                            }
                        }
                    }
                }
            }
        }
    }

    public class NamespaceModel
    {
        public List<string> TopLevelComments { get; set; } = new();

        public string NamespaceName { get; set; }

        public List<string> Usings { get; set; } = new();

        public List<ClassModel> Classes { get; set; } = new();
    }

    public class ClassModel
    {
        public string ClassName { get; set; }

        public bool Partial { get; set; }

        public List<PropertyModel> Properties { get; set; } = new();

        public List<MethodModel> Methods { get; set; } = new();

        public bool IsEmpty => !this.Properties.Any() && !this.Methods.Any();
    }

    public class PropertyModel
    {
        public string FieldName { get; set; }

        public string PropertyName { get; set; }

        public string PropertyType { get; set; }

        public List<string> PropertyAttributes { get; set; } = new();
    }

    public class MethodModel
    {
        public List<MethodArgument> Arguments { get; set; } = new();

        public string ReturnType { get; set; }

        public string MethodName { get; set; }

        public string Body { get; set; }
    }

    public class MethodArgument
    {
        public string Type { get; set; }

        public string Name { get; set; }
    }

    public class PropertyOverrideModel
    {
        public string MatchClassName { get; set; }

        public string MatchFieldName { get; set; }

        public string OverrideType { get; set; }

        public string OverridePropertyName { get; set; }
    }
}
