using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SpecificationEvalution<T> where T : BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecifications<T> spec)
        {
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            if(spec.IsDistinct)
            {
                query = query.Distinct();
            }

            if(spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
        }   
        public static IQueryable<TResult> GetQuery<TSpec,TResult>(IQueryable<T> query, ISpecifications<T,TResult> spec) 
        {
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            var selectedQuery = query as IQueryable<TResult>;
            if(spec.Select != null)
            {
                selectedQuery = query.Select(spec.Select);
            }

            if(spec.IsDistinct)
            {
                selectedQuery = selectedQuery?.Distinct();
            }
             if(spec.IsPaginationEnabled)
            {
                selectedQuery = selectedQuery?.Skip(spec.Skip).Take(spec.Take);
            }
            return selectedQuery ?? query.Cast<TResult>();
        }   
    }
}