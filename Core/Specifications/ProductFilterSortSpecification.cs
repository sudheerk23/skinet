using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductFilterSortSpecification : BaseSpecifcation<Product>
    {
        public ProductFilterSortSpecification(ProductSpecParams specParams) : base(x =>
            (!specParams.Brands.Any() || specParams.Brands.Contains(x.Brand)) && (!specParams.Types.Any() || specParams.Types.Contains(x.Type)) && 
            (!specParams.Search.Any() || x.Name.ToLower().Contains(specParams.Search))
        )
        {
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            switch (specParams.sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderDescBy(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}