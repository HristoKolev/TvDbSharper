using Newtonsoft.Json;

namespace TvDbSharper.Dto
{
#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class Links
    {
        public int? First { get; set; }

        public int? Last { get; set; }

        public int? Next { get; set; }

        public int? Prev { get; set; }
    }
}