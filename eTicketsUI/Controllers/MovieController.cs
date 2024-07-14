using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
using eTickets.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;
        private readonly ICinemaService _cinemaService;

        public MovieController(IMovieService movieService, IActorService actorService, IProducerService producerService, ICinemaService cinemaService)
        {
            _movieService = movieService;
            _actorService = actorService;
            _producerService = producerService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index(string? searchString = null)
        {
            var movies = !String.IsNullOrEmpty(searchString) ? await _movieService.GetAllMovies(searchString) : await _movieService.GetAllMovies();
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
           var movie = await _movieService.GetMovieDetail(id); 
           return View(movie);
        }
        [HttpGet]
        public  async Task<IActionResult> Create() {
            var actors = await _actorService.GetAllActors();
            var producers = await _producerService.GetAllProducers();
            var cinemas = await _cinemaService.GetAllCinemas();
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieReq req)
        {
            if(!ModelState.IsValid)
            {
                var actors = await _actorService.GetAllActors();
                var producers = await _producerService.GetAllProducers();
                var cinemas = await _cinemaService.GetAllCinemas();
                ViewBag.Actors = new SelectList(actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            
                return View();   
            }
            var newMovie = await _movieService.CreateMovie(req);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieDetail(id);
            movie.ActorIds = movie.Actors.Select(a => a.Id).ToList();
            var actors = await _actorService.GetAllActors();
            var producers = await _producerService.GetAllProducers();
            var cinemas = await _cinemaService.GetAllCinemas();
            ViewBag.Actors = new SelectList(actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieReq req)
        {
            if(!ModelState.IsValid)
            {
                var movie = await _movieService.GetMovieDetail(id);
                movie.ActorIds = movie.Actors.Select(a => a.Id).ToList();
                var actors = await _actorService.GetAllActors();
                var producers = await _producerService.GetAllProducers();
                var cinemas = await _cinemaService.GetAllCinemas();
                ViewBag.Actors = new SelectList(actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name");
                return View(movie);
            }
            var updatedMovie = await _movieService.UpdateMovie(id, req);
            return RedirectToAction(nameof(Index));
            
            
        }

    }
}
