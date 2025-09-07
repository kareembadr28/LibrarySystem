using System.Net;

namespace LibrarySystem.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException(string message) : base(message,HttpStatusCode.Conflict)
        {
        }
    }
   
}
