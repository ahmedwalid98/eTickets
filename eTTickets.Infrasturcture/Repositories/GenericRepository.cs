﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTicket.Domain.Repositories;
using eTickets.Infrasturcture.Data;
using Microsoft.EntityFrameworkCore;

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
			context.Set<T>().Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			var query = await context.Set<T>().ToListAsync();
			return query;
		}

		public async Task<T> GetById(int id)
		{
			return await context.Set<T>().SingleOrDefaultAsync(m => m.Id == id);
		}

		public T Update(T entity)
		{
			context.Set<T>().Update(entity);
			return entity;
		}
	}
}
