using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MovieImage { get; set; }
        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<MoviePerson> People { get; set; }
    }
}
