using eTicket.Domain.Entities;
using eTicket.Domain.Specification;
using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MoviesDto>> GetAllMovies(string? searchString = null);
        Task<MoviesDto> GetMovieDetail(int id);
        Task<MoviesDto> CreateMovie(MovieReq movie);
        Task<MoviesDto> UpdateMovie(int id,  MovieReq movie);
    }
}
