using eTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Domain.Specification
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {
       
        
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = [];
        public List<string> IncludeString { get; set; } = new List<string>();

        public Expression<Func<T, object>> OrderBy {  get;private set; }

        public Expression<Func<T, object>> OrderByDescending {  get; private set; }

        public Expression<Func<T, object>> GroupBy {  get; private set; }

        public int Take {  get; private set; }

        public int Skip {  get; private set; }
        public Specification() { }
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public bool IsPagingEnabled { get; private set; } = false;
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddIncludes(string includeString)
        {
            IncludeString.Add(includeString);
        }

        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
