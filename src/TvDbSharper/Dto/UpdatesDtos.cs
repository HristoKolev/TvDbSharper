using Newtonsoft.Json;

namespace TvDbSharper.Dto
{
#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class Update
    {
        public int Id { get; set; }

        public long LastUpdated { get; set; }
    }
}