namespace TvDbSharper.Clients.Updates
{
    using System;

    public static class IntegerExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this int? seconds)
        {
            return Epoch.AddSeconds(seconds.Value);
        }
    }
}