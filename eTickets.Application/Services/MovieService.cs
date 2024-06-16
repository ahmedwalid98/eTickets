using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<MoviesDto>> GetAllMovies(params Expression<Func<Movie, object>>[] expression)
        {
            var movies = await _unitOfWork.MovieRepository.GetAll(expression);

            var moviesDto = movies.Select(movie => new MoviesDto
            {
                Id = movie.Id,
                Price = movie.Price,
                Description = movie.Description,
                Name = movie.Name,
                ImageUrl = movie.ImageUrl,
                Category = nameof(movie.MovieCategory),
                CinemaName = movie.Cinema.Name
            });

            return moviesDto;
        }

        public async Task<MoviesDto> GetMovieDetail(int id)
        {
            var movie = await _unitOfWork.MovieRepository.GetMovieWithDetail(id);
            var moviesDto = new MoviesDto
            {
                Id = movie.Id,
                Price = movie.Price,
                Description = movie.Description,
                Name = movie.Name,
                ImageUrl = movie.ImageUrl,
                Category = nameof(movie.MovieCategory),
                ProducerId = movie.ProducerId,
                ProducerName = movie.Producer.FullName,
                CinemaId = movie.CinemaId,
                CinemaName = movie.Cinema.Name,
                Actors = movie.MoviesActors.Select(m => m.Actor).ToList()
            };

            return moviesDto;

        }
    }
}
