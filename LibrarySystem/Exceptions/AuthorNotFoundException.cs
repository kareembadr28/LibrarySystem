using System.Net;

namespace LibrarySystem.Exceptions
{
    public class AuthorNotFoundException : BaseException
    {
        public AuthorNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
