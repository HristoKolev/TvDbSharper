namespace TvDbSharper.JsonClient.Exceptions
{
    using System;
    using System.Net;

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

        public HttpStatusCode StatusCode { get; set; }
    }
}