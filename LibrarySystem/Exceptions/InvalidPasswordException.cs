using System.Net;

namespace LibrarySystem.Exceptions
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
    {
    }
}
