using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Services;

namespace eTickets.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProducerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Producer>> GetAllProducers()
        {
            return await _unitOfWork.ProducerRepository.GetAll();
        }
    }
}
