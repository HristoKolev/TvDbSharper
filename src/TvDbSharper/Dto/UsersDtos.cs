using Newtonsoft.Json;

namespace TvDbSharper.Dto
{
    public enum RatingType
    {
        Series,

        Episode,

        Image
    }

#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class User
    {
        // ReSharper disable once IdentifierTypo
        public string FavoritesDisplaymode { get; set; }

        public string Language { get; set; }

        public string UserName { get; set; }
    }

#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class UserFavorites
    {
        public string[] Favorites { get; set; }
    }

#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class UserRatings
    {
        public decimal? Rating { get; set; }

        public int? RatingItemId { get; set; }

        public string RatingType { get; set; }
    }
}