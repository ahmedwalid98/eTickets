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
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActorDto> AddActor(ActorReq actor)
        {
            var _actor = new Actor
            {
                FullName = actor.FullName,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Bio = actor.Bio,
            };
            _actor = await _unitOfWork.ActorRepository.Add(_actor);
            _unitOfWork.Commit();
            return new ActorDto
            {
                FullName = _actor.FullName,
                ProfilePictureUrl = _actor.ProfilePictureUrl,
                Bio = _actor.Bio,
            };
        }

        public async Task DeleteActor(int id)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(id);
            _unitOfWork.ActorRepository.Delete(actor);
            _unitOfWork.Commit();
        }

        public async Task<ActorDto> GetActorById(int id)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(id);
            return new ActorDto
            {
                Id = actor.Id,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                FullName = actor.FullName,
                Bio = actor.Bio,
            };
        }

        public async Task<IEnumerable<ActorDto>> GetAllActors()
        {
            var actors = await _unitOfWork.ActorRepository.GetAll();
            return actors.Select(x => new ActorDto
            {
                Id = x.Id,
                ProfilePictureUrl = x.ProfilePictureUrl,
                FullName = x.FullName,
                Bio = x.Bio,
            });
        }

        public async Task<ActorDto> UpdateActor(int id, ActorReq actor)
        {
            var oldActor = await _unitOfWork.ActorRepository.GetById(id);

            if (oldActor != null)
            {
                oldActor.ProfilePictureUrl = actor.ProfilePictureUrl;
                oldActor.FullName = actor.FullName;
                oldActor.Bio = actor.Bio;
                _unitOfWork.ActorRepository.Update(oldActor);
                _unitOfWork.Commit();
            }
            return new ActorDto
            {
                Id = oldActor.Id,
                ProfilePictureUrl = oldActor.ProfilePictureUrl,
                FullName = oldActor.FullName,
                Bio = oldActor.Bio,
            };

        }
    }
}
