using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
