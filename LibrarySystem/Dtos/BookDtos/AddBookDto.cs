namespace LibrarySystem.Dtos.BookDtos
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public List<int> PublisherIds { get; set; } = new List<int>();
    }
}
