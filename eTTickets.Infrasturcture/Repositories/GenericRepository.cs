using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicket.Domain.Repositories;
using eTickets.Infrasturcture.Data;

namespace eTickets.Infrasturcture.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private protected readonly AppDbContext context;

		public GenericRepository(AppDbContext _context)
		{
			context = _context;
		}

		public Task Add(T entity)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task Update(int id, T entity)
		{
			throw new NotImplementedException();
		}
	}
}
