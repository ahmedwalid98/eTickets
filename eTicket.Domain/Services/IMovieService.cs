using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicketsUI.ViewModels;


namespace eTicket.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovies>> GetAllMovies();
    }
}
