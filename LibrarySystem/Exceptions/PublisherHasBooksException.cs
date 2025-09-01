using System.Net;

namespace LibrarySystem.Exceptions
{
    public class PublisherHasBooksException: BaseException
    {
        public PublisherHasBooksException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
