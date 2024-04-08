using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaDto>> GetAllCinemas();
        Task<CinemaDto> GetCinema(int id);
        Task<CinemaDto> UpdateCinema(int id, CinemaReq newCinema);
        Task<CinemaDto> AddCinema(CinemaReq newCinema);
    }
}
