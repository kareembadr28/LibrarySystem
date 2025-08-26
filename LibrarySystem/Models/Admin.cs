using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("Admins")]
    public class Admin : User
    {
        public Admin(string username, string passwordHash, string email) : base(username, passwordHash, email)
        {
        }

        public Admin():base()
        {

        }

    }
}
