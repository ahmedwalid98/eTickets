using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
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

        public async Task<ProducerDto> AddProducer(ProducerReq newProducer)
        {
            var producer = new Producer
            {
                ProfilePictureUrl = newProducer.ProfilePictureUrl,
                FullName = newProducer.FullName,
                Bio = newProducer.Bio,
            };
            producer = await _unitOfWork.ProducerRepository.Add(producer);
            _unitOfWork.Commit();
            return new ProducerDto
            {
                ProfilePictureUrl = producer.ProfilePictureUrl,
                FullName = producer.FullName,
                Bio = producer.Bio,
            };
        }

        public async Task<IEnumerable<ProducerDto>> GetAllProducers()
        {
            var producers = await _unitOfWork.ProducerRepository.GetAll();
            return producers.Select(x => new ProducerDto 
            {
                Id = x.Id,
                FullName = x.FullName,
                ProfilePictureUrl = x.ProfilePictureUrl,
                Bio = x.Bio,
            });
        }

        public async Task<ProducerDto> GetProducerById(int id)
        {
            var producer = await _unitOfWork.ProducerRepository.GetById(id);
            return new ProducerDto
            {
                Id = producer.Id,
                FullName = producer.FullName,
                ProfilePictureUrl = producer.ProfilePictureUrl,
                Bio = producer.Bio,
            };
        }

        public async Task<ProducerDto> UpdateProducer(int id, ProducerReq newProducer)
        {
            var producer = await _unitOfWork.ProducerRepository.GetById(id);
            if (producer != null)
            {
                producer.FullName = newProducer.FullName;
                producer.Bio = newProducer.Bio;
                producer.ProfilePictureUrl = newProducer.ProfilePictureUrl;
                _unitOfWork.ProducerRepository.Update(producer);
                _unitOfWork.Commit();
            }
            return new ProducerDto
            {
                Id = producer.Id,
                FullName = producer.FullName,
                ProfilePictureUrl = producer.ProfilePictureUrl,
                Bio = producer.Bio,
            };
        }
    }
}
