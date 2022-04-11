using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
