namespace TvDbSharper.Clients.Updates
{
    using System;

    public static class LongExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this long? seconds)
        {
            return Epoch.AddSeconds(seconds.Value);
        }
    }
}