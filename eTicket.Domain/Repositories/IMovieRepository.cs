using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;

namespace eTicket.Domain.Repositories
{
	public interface IMovieRepository: IGenericRepository<Movie>
	{
		public Task<Movie> GetMovieWithDetail(int id);
	}
}
