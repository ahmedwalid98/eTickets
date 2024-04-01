using eTicket.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.UI.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await _producerService.GetAllProducers(); 
            return View(producers);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var producer = await _producerService.GetProducerById(id);
            return View(producer);
        }
    }
}
