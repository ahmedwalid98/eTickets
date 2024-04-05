using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTickets.Application.Core.Dtos;
using eTickets.Application.Interfaces;

namespace eTickets.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MoviesDto>> GetAllMovies()
        {
            var movies = await _unitOfWork.MovieRepository.GetAll();

            var moviesDto = movies.Select(movie => new MoviesDto
            {
                Id = movie.Id,
                Price = movie.Price,
                Description = movie.Description,
                Name = movie.Name,
                ImageUrl = movie.ImageUrl,
                Category = nameof(movie.MovieCategory),
                CinemaName = movie.Name
            });

            return moviesDto;
        }
    }
}
