namespace LibrarySystem.Dtos.BorrowDtos
{
    public class BorrowDetailsDto
    {
        public DateTime borrowDate { get; set; }
        public DateTime? returnDate { get; set; }
        public string status { get; set; }
        public string bookTitle { get; set; }
        public string customerName { get; set; }
    }
}
