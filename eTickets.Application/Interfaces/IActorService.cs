using eTicket.Domain.Entities;
using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorDto>> GetAllActors();
        Task<ActorDto> GetActorById(int id);
        Task<ActorDto> UpdateActor(int id, ActorReq updateReq);
        Task<ActorDto> AddActor(ActorReq actor);
    }
}
