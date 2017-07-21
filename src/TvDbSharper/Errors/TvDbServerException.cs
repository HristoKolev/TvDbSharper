namespace TvDbSharper.Errors
{
    using System;
    using System.Net;

    public class TvDbServerException : Exception
    {
        public TvDbServerException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public TvDbServerException(string message, HttpStatusCode statusCode, Exception inner)
            : base(message, inner)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }

        public bool UnknownError { get; set; }
    }
}