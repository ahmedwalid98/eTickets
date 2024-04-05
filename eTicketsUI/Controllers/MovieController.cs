using eTicket.Domain.Services;
using eTicketsUI.ViewModels;
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
            var moviesVM = new List<GetMovies>();
            foreach (var movie in movies)
            {
                moviesVM.Add(new GetMovies
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ImageUrl = movie.ImageUrl,
                    Category = nameof(movie.MovieCategory),
                    CinemaName = movie.Cinema.Name,
                    Price = movie.Price,

                });
            }
            return View(moviesVM);
        }
    }
}
