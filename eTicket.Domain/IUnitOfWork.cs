using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicket.Domain.Repositories;

namespace eTicket.Domain
{
	public interface IUnitOfWork: IDisposable
	{
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        int Commit();

	}
}
