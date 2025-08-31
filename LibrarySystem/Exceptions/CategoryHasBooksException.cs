using System.Net;

namespace LibrarySystem.Exceptions
{
    public class CategoryHasBooksException : BaseException
    {
        public CategoryHasBooksException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
