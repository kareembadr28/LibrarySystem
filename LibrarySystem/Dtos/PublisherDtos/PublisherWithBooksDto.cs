namespace LibrarySystem.Dtos.PublisherDtos
{
    public class PublisherWithBooksDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        
        public List<string> Books { get; set; } = new List<string>();
    }
}
