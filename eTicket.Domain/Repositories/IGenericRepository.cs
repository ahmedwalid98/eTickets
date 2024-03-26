using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;

namespace eTicket.Domain.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id);
		Task<T> Add(T entity);
		T Update(T entity);
		void Delete(T entity);
	}
}
