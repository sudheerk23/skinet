using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetByIdAsync(int id);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        bool Exists(int id);
        Task<bool> SaveChangesAsyc();
        Task<IReadOnlyList<T>> ListAsyc(ISpecifications<T> spec);
        Task<T?> GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<TResult>> ListAsyc<TResult>(ISpecifications<T, TResult> spec);
        Task<TResult?> GetEntityWithSpec<TResult>(ISpecifications<T,TResult> spec);
        
        // Task<T> GetBrandAsync
    


    }
}