using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class BrandListSpecifications : BaseSpecifcation<Product, string>
    {
        public BrandListSpecifications()    
        {
            AddSelect(x => x.Brand);
            AddDistinct();

        }
    }
}