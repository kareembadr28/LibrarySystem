using System.Net;

namespace LibrarySystem.Exceptions
{
    public class DuplicateBookException: BaseException

    {
        public DuplicateBookException(string message) : base(message,HttpStatusCode.Conflict)
        {
        }
    }
}
