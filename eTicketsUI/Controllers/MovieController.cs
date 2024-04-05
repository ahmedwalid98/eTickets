using eTickets.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace eTickets.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMovies();
            
            return View(movies);
        }
    }
}
