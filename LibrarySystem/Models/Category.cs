using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }  
        public string description { get; set; }

        public ICollection<Book> Books { get; set; }=new HashSet<Book>();

        public Category( string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public Category()
        {
        }
    }
}
