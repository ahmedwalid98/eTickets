using eTicket.Domain.Entities;
using eTickets.Application.Core.Request;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProducerReq newProducer)
        {
            var producer = await _producerService.GetProducerById(id);
            producer = await _producerService.UpdateProducer(id, newProducer);
            return View(producer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProducerReq producer)
        {
            if (ModelState.IsValid)
            {
                await _producerService.AddProducer(producer);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _producerService.DeleteProducer(id);
            return Ok();
        }
    }
}
