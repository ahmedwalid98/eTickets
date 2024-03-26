using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Repositories;
using eTickets.Domain.Entities;
using eTickets.Infrasturcture.Data;

namespace eTickets.Infrasturcture.Repositories
{
	public class MovieRepository : GenericRepository<Movie>, IMovieRepository
	{
		public MovieRepository(AppDbContext _context) : base(_context)
		{
		}
	}
}
