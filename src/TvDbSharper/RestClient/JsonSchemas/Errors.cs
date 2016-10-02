namespace TvDbSharper.RestClient.JsonSchemas
{
    using System.Collections.Generic;

    public class Errors
    {
        public List<string> InvalidFilters { get; set; }

        public string InvalidLanguage { get; set; }

        public List<string> InvalidQueryParams { get; set; }
    }
}