namespace LibrarySystem.Dtos.BorrowDtos
{
    public class BorrowDto
    {
        public DateTime borrowDate { get; set; }
        public DateTime? returnDate { get; set; }
        public string status { get; set; }
        public int bookId { get; set; }
        public int customerId { get; set; }
    }
}
