namespace LibrarySystem.Dtos.CategoryDtos
{
    public class CategoryWithBooksDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> BooksNames { get; set; }
    }
}
