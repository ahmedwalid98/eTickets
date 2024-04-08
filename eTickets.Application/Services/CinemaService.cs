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
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CinemaDto> AddCinema(CinemaReq newCinema)
        {
            var cinema = new Cinema
            {
                CinemaLogo = newCinema.CinemaLogo,
                Name = newCinema.Name,
                Description = newCinema.Description,
            };
            cinema = await _unitOfWork.CinemaRepository.Add(cinema);
            _unitOfWork.Commit();
            return new CinemaDto
            {
                CinemaLogo = cinema.CinemaLogo,
                Name = newCinema.Name,
                Description = newCinema.Description,
            };
        }

        public async Task<IEnumerable<CinemaDto>> GetAllCinemas()
        {
            var cinemas = await _unitOfWork.CinemaRepository.GetAll();
            return cinemas.Select(cinema => new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                CinemaLogo = cinema.CinemaLogo,
                Description = cinema.Description
            });
        }

        public async Task<CinemaDto> GetCinema(int id)
        {
            var cinema = await _unitOfWork.CinemaRepository.GetById(id);
            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                CinemaLogo = cinema.CinemaLogo,
                Description = cinema.Description
            };
        }

        public async Task<CinemaDto> UpdateCinema(int id, CinemaReq newCinema)
        {
            var cinema = await _unitOfWork.CinemaRepository.GetById(id);
            if (newCinema != null)
            {
                cinema.CinemaLogo = newCinema.CinemaLogo;
                cinema.Name = newCinema.Name;
                cinema.Description = newCinema.Description;
                _unitOfWork.CinemaRepository.Update(cinema);
                _unitOfWork.Commit();
            }
            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                CinemaLogo = cinema.CinemaLogo,
                Description = cinema.Description
            };
        }
    }
}
