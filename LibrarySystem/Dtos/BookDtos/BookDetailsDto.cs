namespace LibrarySystem.Dtos.BookDtos
{
    public class BookDetailsDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string AuthorName { get; set; }
        public string CategoryName { get; set; }

        public List<string> PublisherNames { get; set; }
    }
}
