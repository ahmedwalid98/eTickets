using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Repositories;
using eTickets.Infrasturcture.Data;
using eTickets.Infrasturcture.Repositories;

namespace eTickets.Infrasturcture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            MovieRepository = new MovieRepository(_context);
            ProducerRepository = new ProducerRepository(_context);
            ActorRepository = new ActorRepository(_context);
            CinemaRepository = new CinemaRepository(_context);
        }

        public IMovieRepository MovieRepository {  get; private set; }

        public IProducerRepository ProducerRepository { get; private set; }

        public IActorRepository ActorRepository { get; private set; }

        public ICinemaRepository CinemaRepository { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
