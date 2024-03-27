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
        IMovieRepository MovieRepository { get; }
        IProducerRepository ProducerRepository { get; }
        IActorRepository ActorRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        int Commit();

	}
}
