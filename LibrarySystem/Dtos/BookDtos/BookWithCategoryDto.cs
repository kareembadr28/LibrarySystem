namespace LibrarySystem.Dtos.BookDtos
{
    public class BookWithCategoryDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
    }
}
