namespace LibrarySystem.Dtos.AuthorDtos
{
    public class AuthorWithBooksDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
