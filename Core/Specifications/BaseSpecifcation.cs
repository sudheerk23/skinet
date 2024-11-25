using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSpecifcation<T>(Expression<Func<T, bool>>? criteria) : ISpecifications<T>
    {
        protected BaseSpecifcation() : this(null) { }
        public Expression<Func<T, bool>>? Criteria => criteria;

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        public bool IsDistinct { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginationEnabled { get; private set; }

        public int Take { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }
        protected void AddOrderDescBy(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }

        protected void AddDistinct()
        {
            IsDistinct = true;
        }

        protected void ApplyPagination(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPaginationEnabled = true;
        }

        public IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            if(Criteria != null)
            {
                query = query.Where(Criteria);
            }
            return query;
        }

        
    }
    public class BaseSpecifcation<T, TResult>(Expression<Func<T, bool>>? criteria) : BaseSpecifcation<T>(criteria), ISpecifications<T, TResult>
    {
        public BaseSpecifcation() : this(null) { }
        public Expression<Func<T, TResult>>? Select { get; private set; }
        protected void AddSelect(Expression<Func<T, TResult>> expression)
        {
            Select = expression;
        }
    }
}