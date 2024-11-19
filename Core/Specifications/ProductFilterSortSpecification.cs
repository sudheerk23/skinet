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
        public ProductFilterSortSpecification(string? brand, string? type, string? sort) : base(x =>
            (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) && (string.IsNullOrWhiteSpace(type) || x.Type == type)
        )
        {
            switch (sort)
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