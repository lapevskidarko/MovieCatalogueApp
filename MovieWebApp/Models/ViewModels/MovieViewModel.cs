using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieWebApp.Models.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public string[] SelectedGenresIds { get; set; }
        public List<SelectListItem>? People { get; set; }
        public string[] SelectedPersonIds { get; set; }
    }
}
