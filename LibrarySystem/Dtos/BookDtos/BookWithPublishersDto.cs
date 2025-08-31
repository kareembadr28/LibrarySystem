namespace LibrarySystem.Dtos.BookDtos
{
    public class BookWithPublishersDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<string> Publishers { get; set; }
    }
}
