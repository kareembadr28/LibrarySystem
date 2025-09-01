using System.Net;

namespace LibrarySystem.Exceptions
{
    public class BorrowNotFoundException : BaseException
    {
        public BorrowNotFoundException(string message) : base(message,HttpStatusCode.NotFound)
        {
        }
    }
}
