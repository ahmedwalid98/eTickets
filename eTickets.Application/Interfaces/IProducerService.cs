using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerDto>> GetAllProducers();
        Task<ProducerDto> GetProducerById(int id);
        Task<ProducerDto> UpdateProducer(int id, ProducerReq newProducer);
        Task<ProducerDto> AddProducer(ProducerReq newProducer);
    }
}
