using System.Net;

namespace LibrarySystem.Exceptions
{
    public class InvalidRoleException : BaseException
    {
        public InvalidRoleException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
    {
    }
}
