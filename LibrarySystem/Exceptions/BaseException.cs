using System.Net;

namespace LibrarySystem.Exceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode statusCode { get; }
        public BaseException(string message, HttpStatusCode statusCode) : base(message)
        {
            this.statusCode = statusCode;
        }
    }
}
