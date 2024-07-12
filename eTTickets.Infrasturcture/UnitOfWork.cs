using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain;
using eTicket.Domain.Entities;
using eTicket.Domain.Repositories;
using eTickets.Infrasturcture.Data;
using eTickets.Infrasturcture.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Infrasturcture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private Hashtable _repositories;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
            
        }
   
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories.Add(key, repository);
            }

            return _repositories[key] as IGenericRepository<T>;
        }
    }
}
