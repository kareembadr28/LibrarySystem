using System.Net;

namespace LibrarySystem.Exceptions
{
    public class PublisherAlreadyExistsException: BaseException
    {
        public PublisherAlreadyExistsException(string message) : base(message,HttpStatusCode.Conflict)
        {
        }
    }
    
}
