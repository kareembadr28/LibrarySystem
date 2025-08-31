namespace LibrarySystem.Dtos.BookDtos
{
    public class BookWithAuthorDto
    {
        public String Title { get; set; }
        public String ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public String AuthorName { get; set; }
    }
}
