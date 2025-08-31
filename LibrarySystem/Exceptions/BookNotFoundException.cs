using System.Net;

namespace LibrarySystem.Exceptions
{
    public class BookNotFoundException: BaseException
    {
        public BookNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
