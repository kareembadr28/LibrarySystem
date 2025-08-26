using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Publishers")]
    public class Publisher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contactEmail { get; set; }
        public string phone { get; set; }

        public ICollection<Book> Books { get; set; }= new HashSet<Book>();

        public Publisher(string name, string address, string contactEmail, string phone)
        {
            this.name = name;
            this.address = address;
            this.contactEmail = contactEmail;
            this.phone = phone;
        }

        public Publisher()
        {
        }
    }
}
