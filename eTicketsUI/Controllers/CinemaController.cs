using eTicket.Domain.Entities;
using eTickets.Application.Core.Request;
using eTickets.Application.Interfaces;
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

        public async Task<IActionResult> Detail(int id)
        {
            var cinema = await _cinemaService.GetCinema(id);
            return View(cinema);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetCinema(id);
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync([FromRoute] int id, CinemaReq newCinema)
            
        {
            var cinema = await _cinemaService.GetCinema(id);
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            cinema = await _cinemaService.UpdateCinema(id,newCinema);
            return View(cinema);
        }
    }
}
