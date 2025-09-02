namespace LibrarySystem.Dtos.BorrowDtos
{
    public class ReturnBorrowDto
    {
        public DateTime borrowDate { get; set; }
        public DateTime? returnDate { get; set; }
        public string status { get; set; }
        public string bookTitle { get; set; }
        public string customerName { get; set; }
        public decimal fine { get; set; }
    }
}
