using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
