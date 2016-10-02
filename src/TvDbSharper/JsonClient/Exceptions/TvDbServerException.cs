namespace TvDbSharper.JsonClient.Exceptions
{
    using System;

    public class TvDbServerException : Exception
    {
        public TvDbServerException()
        {
        }

        public TvDbServerException(string message)
            : base(message)
        {
        }

        public TvDbServerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}