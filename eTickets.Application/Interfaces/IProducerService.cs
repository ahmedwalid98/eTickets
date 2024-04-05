using eTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAllProducers();
        Task<Producer> GetProducerById(int id);
        Task<Producer> UpdateProducer(int id, Producer newProducer);
    }
}
