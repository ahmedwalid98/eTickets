using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Services;
using eTicketsUI.ViewModels;
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
		public async Task<IActionResult> Detail(int id)
		{
			var actor = await _actorService.GetActorById(id);
			return View(actor);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var actor = await _actorService.GetActorById(id);
			return View(actor);
		}
		[HttpPost]
		public async Task<IActionResult> Edit([FromRoute] int id, EditActorVM newActor)
		{
            var actor = await _actorService.GetActorById(id);
			if (!ModelState.IsValid)
			{
				return View(actor);
			}
			actor = await _actorService.UpdateActor(id, newActor);
            return View(actor);
        }
	}
}
