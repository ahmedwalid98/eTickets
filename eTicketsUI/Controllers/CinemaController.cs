using eTicket.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.UI.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllCinemas();
            return View(cinemas);
        }
    }
}
