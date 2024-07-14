using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Specification.MovieSpecification;
using eTickets.Application.Core.Dtos;
using eTickets.Application.Core.Request;
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

        public async Task<MoviesDto> CreateMovie(MovieReq movie)
        {
            var newMovie = new Movie
            {
                Name = movie.Name,
                Description = movie.Description,
                ImageUrl = movie.ImageURL,
                MovieCategory = movie.MovieCategory,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MoviesActors = movie.ActorIds.Select(id => new MovieActor { ActorId = id }).ToList(),
            };
            await _unitOfWork.Repository<Movie>().Add(newMovie);
            _unitOfWork.Commit();
            
            return new MoviesDto
            {
                Name = newMovie.Name,
                Description = newMovie.Description,
                ImageUrl = newMovie.ImageUrl,
                MovieCategory = newMovie.MovieCategory,
                CinemaId = newMovie.CinemaId,
                ProducerId = newMovie.ProducerId,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
            };
        }

        public async Task<IEnumerable<MoviesDto>> GetAllMovies(string? searchString = null)
           
        {
            var specs = !String.IsNullOrEmpty(searchString) ? new GetAllMoviesSpecs(searchString) : new GetAllMoviesSpecs();
            var movies = await _unitOfWork.Repository<Movie>().GetAll(specs);
            var moviesDto = movies.Select(movie => new MoviesDto
            {
                Id = movie.Id,
                Price = movie.Price,
                Description = movie.Description,
                Name = movie.Name,
                ImageUrl = movie.ImageUrl,
                Category = nameof(movie.MovieCategory),
                CinemaName = movie.Cinema.Name,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
            });

            return moviesDto;
        }

        public async Task<MoviesDto> GetMovieDetail(int id)
        {
            var movieSpec = new GetMovieWithActorsCinemaProducer();
            var movie = await _unitOfWork.Repository<Movie>().GetById(id, movieSpec);
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
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                CinemaId = movie.CinemaId,
                CinemaName = movie.Cinema.Name,
                Actors = movie.MoviesActors.Select(m => m.Actor).ToList()
            };

            return moviesDto;

        }

        public async Task<MoviesDto> UpdateMovie(int id, MovieReq movie)
        {
            var movieSpec = new GetMovieWithActorsCinemaProducer();
            var oldMovie = await _unitOfWork.Repository<Movie>().GetById(id, movieSpec);
            oldMovie.Name = movie.Name;
            oldMovie.Price = movie.Price;
            oldMovie.Description = movie.Description;
            oldMovie.MovieCategory = movie.MovieCategory;
            oldMovie.ProducerId = movie.ProducerId;
            oldMovie.CinemaId = movie.CinemaId;
            oldMovie.Description = movie.Description;
            oldMovie.EndDate = movie.EndDate;
            oldMovie.StartDate = movie.StartDate;
            oldMovie.ImageUrl = movie.ImageURL;
            oldMovie.MoviesActors = movie.ActorIds.Select(a => new MovieActor { ActorId = a}).ToList();
            var updatedMovie = _unitOfWork.Repository<Movie>().Update(oldMovie);
            _unitOfWork.Commit();
            return new MoviesDto
            {
                Id = updatedMovie.Id,
                Price = updatedMovie.Price,
                Description = updatedMovie.Description,
                Name = updatedMovie.Name,
                ImageUrl = updatedMovie.ImageUrl,
                Category = nameof(updatedMovie.MovieCategory),
                ProducerId = updatedMovie.ProducerId,
                ProducerName = updatedMovie.Producer.FullName,
                CinemaId = updatedMovie.CinemaId,
                CinemaName = updatedMovie.Cinema.Name,
                Actors = updatedMovie.MoviesActors.Select(m => m.Actor).ToList()
            };
        }
    }
}
