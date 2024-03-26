using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Repositories;

namespace eTicket.Domain
{
	public interface IUnitOfWork: IDisposable
	{
        public IMovieRepository MovieRepository { get; }
        public IProducerRepository ProducerRepository { get; }
        public IActorRepository ActorRepository { get; }
        public ICinemaRepository CinemaRepository { get; }
        int Commit();

	}
}
