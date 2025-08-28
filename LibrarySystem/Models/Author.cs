using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Authors")]
    public class Author
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string bio { get; set; }

       public ICollection<Book> Books { get; set; }=new HashSet<Book>();

        public Author(string fullName, string bio)
        {
            this.fullName = fullName;
            this.bio = bio;
        }

        public Author()
        {
        }
    }
}
