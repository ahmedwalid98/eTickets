using eTicket.Domain.Entities;
using eTicket.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Infrasturcture
{
    public static class SpecificationEvaluator<T> where T: BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specs)
        {
            var query = inputQuery;
            if(specs.Criteria is not null)
            {
                query = query.Where(specs.Criteria);
            }
            if(specs.GroupBy is not null)
                query.GroupBy(specs.GroupBy);
            if(specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);

            if(specs.OrderByDescending is not null)
                query = query.OrderByDescending(specs.OrderByDescending);
            if(specs.IsPagingEnabled)
            {
                query = query.Skip(specs.Skip).Take(specs.Take);
            }
            query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));
            query = specs.IncludeString.Aggregate(query,
                               (current, include) => current.Include(include));
            return query;
        }
    }
}
