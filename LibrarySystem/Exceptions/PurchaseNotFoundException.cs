using System.Net;

namespace LibrarySystem.Exceptions
{
    public class PurchaseNotFoundException:BaseException
    {
        public PurchaseNotFoundException(string message) : base(message,HttpStatusCode.NotFound)
        {
        }
    }
}
