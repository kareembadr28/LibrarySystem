using System.Net;

namespace LibrarySystem.Exceptions
{
    public class CustomerNotFoundException : BaseException
    {
        public CustomerNotFoundException(string message) : base(message,HttpStatusCode.NotFound)
        {
        }
    }
}
