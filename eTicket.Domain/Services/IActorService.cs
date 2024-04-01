using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;

namespace eTicket.Domain.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllActors();
        Task<Actor> GetActorById(int id);
    }
}
