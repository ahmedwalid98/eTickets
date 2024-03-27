using eTicket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.UI.Controllers
{
	public class ActorController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
		{
			var actors = await _unitOfWork.ActorRepository.GetAll();
			return View(actors);
		}
	}
}
