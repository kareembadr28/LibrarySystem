using System.Net;

namespace LibrarySystem.Exceptions
{
    public class BookOutOfStockException: BaseException
    {
        public BookOutOfStockException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
    
}
