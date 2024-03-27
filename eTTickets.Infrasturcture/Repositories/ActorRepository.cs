using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Repositories;
using eTicket.Domain.Entities;
using eTickets.Infrasturcture.Data;

namespace eTickets.Infrasturcture.Repositories
{
	public class ActorRepository : GenericRepository<Actor>, IActorRepository
	{
		public ActorRepository(AppDbContext _context) : base(_context)
		{
		}
	}
}
