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
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas()
        {
            return await _unitOfWork.CinemaRepository.GetAll();
        }

        public async Task<Cinema> GetCinema(int id)
        {
            return await _unitOfWork.CinemaRepository.GetById(id);
        }
    }
}
