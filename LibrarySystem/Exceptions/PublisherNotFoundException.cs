using System.Net;

namespace LibrarySystem.Exceptions
{
    public class PublisherNotFoundException:BaseException
    {
        public PublisherNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
