using System.Net;

namespace LibrarySystem.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
    
}
