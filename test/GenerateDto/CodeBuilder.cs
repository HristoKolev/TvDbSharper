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
            { "getAllInspirationTypes", "InspirationTypes" },
        };

        private static readonly List<PropertyOverrideModel> PropertyOverrides = new()
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
            new()
            {
                MatchClassName = "MovieBaseRecordDto",
                MatchFieldName = "score",
                OverrideType = "double?",
            },
            new()
            {
                MatchClassName = "CharacterDto",
                MatchFieldName = "episodeId",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "CharacterDto",
                MatchFieldName = "movieId",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "CompanyTypeDto",
                MatchFieldName = "id",
                OverrideFieldName = "companyTypeId",
                OverridePropertyName = "CompanyTypeId",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"companyTypeId\")]",
                },
            },
            new()
            {
                MatchClassName = "CompanyTypeDto",
                MatchFieldName = "name",
                OverrideFieldName = "companyTypeName",
                OverridePropertyName = "CompanyTypeName",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"companyTypeName\")]",
                },
            },
            new()
            {
                MatchClassName = "SeasonTypeDto",
                MatchFieldName = "type",
                OverrideType = "string",
            },
            new()
            {
                MatchClassName = "CompaniesDto",
                MatchFieldName = "specialEffects",
                OverrideFieldName = "special_effects",
                OverrideType = "CompanyDto[]",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"special_effects\")]",
                },
            },
            new()
            {
                MatchClassName = "CompaniesDto",
                MatchFieldName = "studio",
                OverrideType = "CompanyDto[]",
            },
            new()
            {
                MatchClassName = "CompaniesDto",
                MatchFieldName = "network",
                OverrideType = "CompanyDto[]",
            },
            new()
            {
                MatchClassName = "CompaniesDto",
                MatchFieldName = "production",
                OverrideType = "CompanyDto[]",
            },
            new()
            {
                MatchClassName = "CompaniesDto",
                MatchFieldName = "distributor",
                OverrideType = "CompanyDto[]",
            },
            new()
            {
                MatchClassName = "EpisodeExtendedRecordDto",
                MatchFieldName = "airsAfterSeason",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "EpisodeExtendedRecordDto",
                MatchFieldName = "airsBeforeSeason",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "EpisodeExtendedRecordDto",
                MatchFieldName = "airsBeforeEpisode",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "EntityDto",
                MatchFieldName = "seriesId",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "MovieBaseRecordDto",
                MatchFieldName = "runtime",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "MovieExtendedRecordDto",
                MatchFieldName = "score",
                OverrideType = "double?",
            },
            new()
            {
                MatchClassName = "CharacterDto",
                MatchFieldName = "seriesId",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "MovieExtendedRecordDto",
                MatchFieldName = "productionCountries",
                OverrideFieldName = "production_countries",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"production_countries\")]",
                },
            },
            new()
            {
                MatchClassName = "MovieExtendedRecordDto",
                MatchFieldName = "spokenLanguages",
                OverrideFieldName = "spoken_languages",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"spoken_languages\")]",
                },
            },
            new()
            {
                MatchClassName = "MovieExtendedRecordDto",
                MatchFieldName = "firstRelease",
                OverrideFieldName = "first_release",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"first_release\")]",
                },
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "extendedTitle",
                OverrideFieldName = "extended_title",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"extended_title\")]",
                },
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "imageUrl",
                OverrideFieldName = "image_url",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"image_url\")]",
                },
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "primaryLanguage",
                OverrideFieldName = "primary_language",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"primary_language\")]",
                },
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "translations",
                OverrideType = "Dictionary<string, string>",
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "overviews",
                OverrideType = "Dictionary<string, string>",
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "remoteIds",
                OverrideFieldName = "remote_ids",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"remote_ids\")]",
                },
            },
            new()
            {
                MatchClassName = "SearchResultDto",
                MatchFieldName = "nameTranslated",
                OverrideFieldName = "name_translated",
                OverridePropertyAttributes = new List<string>
                {
                    "[JsonProperty(\"name_translated\")]",
                },
            },
            new()
            {
                MatchClassName = "SeasonBaseRecordDto",
                MatchFieldName = "imageType",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "SeasonExtendedRecordDto",
                MatchFieldName = "type",
                OverrideType = "SeasonTypeDto",
            },
            new()
            {
                MatchClassName = "SeasonExtendedRecordDto",
                MatchFieldName = "imageType",
                OverrideType = "int?",
            },
            new()
            {
                MatchClassName = "StatusDto",
                MatchFieldName = "id",
                OverrideType = "long?",
            },
            new()
            {
                MatchClassName = "ArtworkExtendedRecordDto",
                MatchFieldName = "seriesId",
                OverrideType = "int?",
            },
        };

        private static readonly Dictionary<string, List<PropertyModel>> ExtraProperties = new()
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
            {
                "MovieBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "runtime",
                        PropertyName = "Runtime",
                        PropertyType = "int",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"runtime\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                }
            },
            {
                "CharacterDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "peopleType",
                        PropertyName = "PeopleType",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"peopleType\")]",
                        },
                    },
                }
            },
            {
                "CompanyDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "companyType",
                        PropertyName = "CompanyType",
                        PropertyType = "CompanyTypeDto",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"companyType\")]",
                        },
                    },
                }
            },
            {
                "ContentRatingDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "description",
                        PropertyName = "Description",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"description\")]",
                        },
                    },
                }
            },
            {
                "EntityTypeDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "hasSpecials",
                        PropertyName = "HasSpecials",
                        PropertyType = "bool",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"hasSpecials\")]",
                        },
                    },
                }
            },
            {
                "EpisodeBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "overview",
                        PropertyName = "Overview",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"overview\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "finaleType",
                        PropertyName = "FinaleType",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"finaleType\")]",
                        },
                    },
                }
            },
            {
                "SeasonBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "companies",
                        PropertyName = "Companies",
                        PropertyType = "CompaniesDto",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"companies\")]",
                        },
                    },
                }
            },
            {
                "EpisodeExtendedRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "overview",
                        PropertyName = "Overview",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"overview\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "finaleType",
                        PropertyName = "FinaleType",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"finaleType\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "nominations",
                        PropertyName = "Nominations",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"nominations\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "networks",
                        PropertyName = "Networks",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"networks\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "studios",
                        PropertyName = "Studios",
                        PropertyType = "StudioBaseRecordDto[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"studios\")]",
                        },
                    },
                }
            },
            {
                "ListBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "score",
                        PropertyName = "Score",
                        PropertyType = "int",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"score\")]",
                        },
                    },
                }
            },
            {
                "MovieExtendedRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "runtime",
                        PropertyName = "Runtime",
                        PropertyType = "int",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"runtime\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                }
            },
            {
                "PeopleBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "nameTranslations",
                        PropertyName = "NameTranslations",
                        PropertyType = "string[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"nameTranslations\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "overviewTranslations",
                        PropertyName = "OverviewTranslations",
                        PropertyType = "string[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"overviewTranslations\")]",
                        },
                    },
                }
            },
            {
                "PeopleExtendedRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "nameTranslations",
                        PropertyName = "NameTranslations",
                        PropertyType = "string[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"nameTranslations\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "overviewTranslations",
                        PropertyName = "OverviewTranslations",
                        PropertyType = "string[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"overviewTranslations\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "translations",
                        PropertyName = "Translations",
                        PropertyType = "object",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonIgnore]",
                        },
                    },
                }
            },
            {
                "SearchResultDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "objectID",
                        PropertyName = "ObjectID",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"objectID\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "studios",
                        PropertyName = "Studios",
                        PropertyType = "string[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"studios\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "first_air_time",
                        PropertyName = "FirstAirTime",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"first_air_time\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "slug",
                        PropertyName = "Slug",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"slug\")]",
                        },
                    },
                }
            },
            {
                "SeriesBaseRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "averageRuntime",
                        PropertyName = "AverageRuntime",
                        PropertyType = "int?",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"averageRuntime\")]",
                        },
                    },
                }
            },
            {
                "SeriesExtendedRecordDto", new List<PropertyModel>
                {
                    new()
                    {
                        FieldName = "lastUpdated",
                        PropertyName = "LastUpdated",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"lastUpdated\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "averageRuntime",
                        PropertyName = "AverageRuntime",
                        PropertyType = "int?",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"averageRuntime\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "airsTimeUTC",
                        PropertyName = "AirsTimeUTC",
                        PropertyType = "string",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"airsTimeUTC\")]",
                        },
                    },
                    new()
                    {
                        FieldName = "translations",
                        PropertyName = "Translations",
                        PropertyType = "object",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonIgnore]",
                        },
                    },
                    new()
                    {
                        FieldName = "episodes",
                        PropertyName = "Episodes",
                        PropertyType = "EpisodeBaseRecordDto[]",
                        PropertyAttributes = new List<string>
                        {
                            "[JsonProperty(\"episodes\")]",
                        },
                    },
                }
            },
        };

        private static readonly Dictionary<string, string> MethodReturnTypeOverrides = new()
        {
            { "getSeriesEpisodes", "GetSeriesEpisodesResponseData" },
            { "getSeriesSeasonEpisodesTranslated", "SeriesExtendedRecordDto" },
            { "getListTranslation", "TranslationDto[]" },
            { "getSeasonTypes", "SeasonTypeDto[]" },
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
                    "System.Collections.Generic",
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
                    ReturnType = $"Task<TvDbApiResponse<{returnType}>>",
                    Body = $"return this.Get<{returnType}>($\"{url}\", null, cancellationToken);",
                });

                // Without CT
                tvdbClient.Methods.Add(new MethodModel
                {
                    MethodName = methodName,
                    Arguments = methodArgumentsMap.Values.ToList(),
                    ReturnType = $"Task<TvDbApiResponse<{returnType}>>",
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
                        ReturnType = $"Task<TvDbApiResponse<{returnType}>>",
                        Body = $"return this.Get<{returnType}>($\"{url}\", optionalParameters, cancellationToken);",
                    });

                    // With optional parameters and without CT
                    tvdbClient.Methods.Add(new MethodModel
                    {
                        MethodName = methodName,
                        Arguments = methodArgumentsMap.Values.Concat(new[]
                        {
                            new MethodArgument { Type = optionalParamsClassName, Name = "optionalParameters" },
                        }).ToList(),
                        ReturnType = $"Task<TvDbApiResponse<{returnType}>>",
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
            if (MethodReturnTypeOverrides.ContainsKey(requestInfo.OperationId))
            {
                return MethodReturnTypeOverrides[requestInfo.OperationId];
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
            foreach (var classModel in namespaceModel.Classes)
            {
                if (ExtraProperties.ContainsKey(classModel.ClassName))
                {
                    classModel.Properties.AddRange(ExtraProperties[classModel.ClassName]);
                }

                foreach (var modelProperty in classModel.Properties)
                {
                    foreach (var overrideModel in PropertyOverrides)
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

                            if (overrideModel.OverrideFieldName != null)
                            {
                                modelProperty.FieldName = overrideModel.OverrideFieldName;
                            }

                            if (overrideModel.OverridePropertyAttributes.Any())
                            {
                                modelProperty.PropertyAttributes = overrideModel.OverridePropertyAttributes;
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

        public string OverrideFieldName { get; set; }

        public List<string> OverridePropertyAttributes { get; set; } = new();
    }
}
