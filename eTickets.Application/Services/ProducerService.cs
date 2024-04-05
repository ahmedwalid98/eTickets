using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTickets.Application.Interfaces;

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

        public async Task<Producer> GetProducerById(int id)
        {
            return await _unitOfWork.ProducerRepository.GetById(id);
        }

        public async Task<Producer> UpdateProducer(int id, Producer newProducer)
        {
            var producer = await GetProducerById(id);
            if (producer != null)
            {
                producer.FullName = newProducer.FullName;
                producer.Bio = newProducer.Bio;
                producer.ProfilePictureUrl = newProducer.ProfilePictureUrl;
                _unitOfWork.ProducerRepository.Update(producer);
                _unitOfWork.Commit();
            }
            return producer;
        }
    }
}
