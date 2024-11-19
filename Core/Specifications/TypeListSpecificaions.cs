using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class TypeListSpecificaions : BaseSpecifcation<Product,string>
    {
        public TypeListSpecificaions()
        {
            AddSelect(x => x.Type);
            AddDistinct();
        }
    }
}