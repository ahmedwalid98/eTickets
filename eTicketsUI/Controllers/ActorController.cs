using eTicket.Domain;
using eTicket.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.UI.Controllers
{
	public class ActorController : Controller
	{
		private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        

        public async Task<IActionResult> Index()
		{
			var actors = await _actorService.GetAllActors();
			return View(actors);
		}
	}
}
