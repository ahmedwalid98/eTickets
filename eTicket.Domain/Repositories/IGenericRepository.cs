using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicket.Domain.Specification;

namespace eTicket.Domain.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(ISpecification<T> spec = null);
        Task<T> GetById(int id);
        Task<T> GetById(int id, ISpecification<T> spec = null);
        Task<T> Add(T entity);
		T Update(T entity);
		void Delete(T entity);
	}
}
