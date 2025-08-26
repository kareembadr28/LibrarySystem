using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    [Table("SuperAdmins")]
    public class SuperAdmin : User
    {
        public SuperAdmin(string username, string passwordHash, string email) : base(username, passwordHash, email)
        {
        }
        public SuperAdmin() : base()
        {
        }
    }
}
