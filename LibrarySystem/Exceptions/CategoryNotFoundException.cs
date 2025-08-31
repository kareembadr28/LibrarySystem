using System.Net;

namespace LibrarySystem.Exceptions
{
    public class CategoryNotFoundException : BaseException
    {
        public CategoryNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
