using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Services;
using eTicketsUI.ViewModels;

namespace eTickets.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetMovies>> GetAllMovies()
        {
            var movies = await _unitOfWork.MovieRepository.GetAll();
            var moviesVM = new List<GetMovies>();
            foreach (var movie in movies)
            {
                moviesVM.Add(new GetMovies
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ImageUrl = movie.ImageUrl,
                    Category = nameof(movie.MovieCategory),
                    CinemaName = movie.Cinema.Name,
                    Price = movie.Price,
                    StartDate = movie.StartDate,
                    EndDate = movie.EndDate,
                }); 
            }
            return moviesVM;
        }
    }
}
