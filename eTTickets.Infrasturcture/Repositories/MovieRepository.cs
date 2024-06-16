using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Repositories;
using eTicket.Domain.Entities;
using eTickets.Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Infrasturcture.Repositories
{
	public class MovieRepository : GenericRepository<Movie>, IMovieRepository
	{
		public MovieRepository(AppDbContext _context) : base(_context)
		{
		}

        public async Task<Movie> GetMovieWithDetail(int id)
        {
            return await context.Set<Movie>().Include(m => m.Cinema).Include(m => m.Producer).Include(m => m.MoviesActors).ThenInclude(ma => ma.Actor).SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
