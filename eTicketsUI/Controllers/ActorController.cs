using eTicket.Domain.Entities;
using eTickets.Application.Core.Request;
using eTickets.Application.Interfaces;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, ActorReq newActor)
        {
            var actor = await _actorService.GetActorById(id);
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            actor = await _actorService.UpdateActor(id, newActor);
            return View(actor);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorReq actor)
        {
            if (ModelState.IsValid)
            {
                var newActor = await _actorService.AddActor(actor);
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _actorService.DeleteActor(id);
            return Ok();
        }
    }
}
