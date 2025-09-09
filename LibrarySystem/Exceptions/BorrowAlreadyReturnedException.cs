namespace LibrarySystem.Exceptions
{
    public class BorrowAlreadyReturnedException : BaseException
    {
        public BorrowAlreadyReturnedException(string message) : base(message,HttpStatusCode.BadRequest)
        {
        }
    }
}
