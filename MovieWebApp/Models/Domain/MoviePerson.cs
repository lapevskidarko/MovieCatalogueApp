using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Domain
{
    public class MoviePerson
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
