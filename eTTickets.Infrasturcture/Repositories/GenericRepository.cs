﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicket.Domain.Repositories;
using eTicket.Domain.Specification;
using eTickets.Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eTickets.Infrasturcture.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private protected readonly AppDbContext context;

		public GenericRepository(AppDbContext _context)
		{
			context = _context;
		}

		public async Task<T> Add(T entity)
		{
			await context.Set<T>().AddAsync(entity);
			return entity;
		}

		public void Delete(T entity)
		{
			context.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			
              return await context.Set<T>().AsNoTracking().ToListAsync();
			
		}

        public async Task<IEnumerable<T>> GetAll(ISpecification<T> specs)
        {
			return await ApplySpecification(specs).ToListAsync();
        }

        public async Task<T> GetById(int id)
		{
			return await context.Set<T>().SingleOrDefaultAsync(m => m.Id == id);
		}

        public async Task<T> GetById(int id, ISpecification<T> specs)
        {
			return await ApplySpecification(specs).SingleOrDefaultAsync(m => m.Id == id);
        }

        public T Update(T entity)
		{
			context.Set<T>().Update(entity);
			return entity;
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> specs)
		{
			return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), specs);
		}
	}
}
