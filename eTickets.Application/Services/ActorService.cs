using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Services;
/*using eTicketsUI.ViewModels;
*/
namespace eTickets.Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Actor> GetActorById(int id)
        {
            return await _unitOfWork.ActorRepository.GetById(id);
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            return await _unitOfWork.ActorRepository.GetAll();
        }

        public async Task<Actor> UpdateActor(int id, Actor actor)
        {
            var oldActor = await GetActorById(id);

            if (oldActor != null)
            {
                oldActor.ProfilePictureUrl = actor.ProfilePictureUrl;
                oldActor.FullName = actor.FullName;
                oldActor.Bio = actor.Bio;
                _unitOfWork.ActorRepository.Update(oldActor);
                _unitOfWork.Commit();
            }
            return oldActor;

        }
    }
}
