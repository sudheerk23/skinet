using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISpecifications<T>
    {
        Expression<Func<T,bool>>? Criteria {get;}
        Expression<Func<T,object>>? OrderBy {get;}
        Expression<Func<T,object>>? OrderByDesc {get;}
        
        bool IsDistinct {get;}
    }

    public interface ISpecifications<T,TResult> : ISpecifications<T>
    {
        Expression<Func<T,TResult>>? Select {get; }
    }
}