using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models.Domain;
using MovieWebApp.Models.ViewModels;

namespace MovieWebApp.Controllers
{
    public class MovieController : Controller
    {
            private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult>  Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            MovieViewModel movie = new MovieViewModel();
            movie.Genres = _context.Genres.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            movie.People = _context.People.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            model.Genres = _context.Genres.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            model.People = _context.People.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();
            if (ModelState.IsValid)
            {
                Movie newMovie = new Movie();
                newMovie.Name = model.Name;
                newMovie.Description = model.Description;
                newMovie.MovieImage = model.MovieImage;
                _context.Add(newMovie);
                await _context.SaveChangesAsync();

                if (model.SelectedGenresIds != null && model.SelectedGenresIds.Any())
                {
                    foreach (var id in model.SelectedGenresIds)
                    {
                        MovieGenre movieGenre = new MovieGenre();
                        movieGenre.MovieId = newMovie.Id;
                        movieGenre.GenreId = Int32.Parse(id);
                        _context.MovieGenres.Add(movieGenre);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
            MovieViewModel model = new MovieViewModel();

            if (movie != null)
            {

                model.Id = movie.Id;
                model.Name = movie.Name;
                model.Description = movie.Description;
                model.MovieImage = movie.MovieImage;
                model.Genres = _context.Genres.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                model.People = _context.People.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();
            }
                return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieViewModel movie)
        {
            movie.Genres = _context.Genres.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            movie.People = _context.People.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();
            var model = await _context.Movies.SingleOrDefaultAsync(x => x.Id == movie.Id);
            if (model != null)
            {
                model.Name = movie.Name;
                model.Description = movie.Description;
                model.MovieImage = movie.MovieImage;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
               }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
