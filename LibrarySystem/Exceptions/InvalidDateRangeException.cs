using System.Net;

namespace LibrarySystem.Exceptions
{
    public class InvalidDateRangeException:BaseException
    {
        public InvalidDateRangeException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
