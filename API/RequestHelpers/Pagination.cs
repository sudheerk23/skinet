using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RequestHelpers
{
    public class Pagination<T>(int pageSize,int pageIndex, int count, IReadOnlyList<T> data)
    {
        public int PageSize { get; set; } = pageSize;
        public int PageIndex { get; set; } = pageIndex;
        public int Count { get; set; } = count;
        public IReadOnlyList<T>? Data { get; set; } = data;
    }
}