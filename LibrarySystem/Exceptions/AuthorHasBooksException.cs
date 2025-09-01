using System.Net;

namespace LibrarySystem.Exceptions
{
    public class AuthorHasBooksException:BaseException
    {
        public AuthorHasBooksException(string message) : base(message,HttpStatusCode.BadRequest)
        {
        }
    }
}
