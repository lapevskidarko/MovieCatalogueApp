using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class Person
    {
       [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
