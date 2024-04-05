using eTicket.Domain.Entities;
using eTickets.Application.Interfaces;
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producerService.GetProducerById(id);
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer newProducer)
        {
            var producer = await _producerService.GetProducerById(id);
            producer = await _producerService.UpdateProducer(id, newProducer);
            return View(producer);
        }
    }
}
