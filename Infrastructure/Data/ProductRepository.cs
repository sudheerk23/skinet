using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository(StoreContent context) : IProductRepository
    {
        public void CreateProduct(Product product)
        {
            context.products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            context.products.Remove(product);
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync(string? brand, string? type,string? sort)
        {
            var query = context.products.AsQueryable();
            if(!string.IsNullOrWhiteSpace(brand))
                query = context.products.Where(x => x.Brand == brand);
            if(!string.IsNullOrEmpty(type))
                query = context.products.Where(x => x.Type == type);

            query = sort switch
            {
                "priceAsc" => query.OrderBy(x => x.Price),
                "priceDesc" => query.OrderByDescending(x => x.Price),
                _ => query.OrderBy(x => x.Name),
            };
            
            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            return await context.products.FindAsync(Id);
        }

        public bool ProductExists(int id)
        {
           return  context.products.Any(i => i.Id == id);
        }

        public void UpdateProduct(Product product)
        {
           context.Entry(product).State = EntityState.Modified;

        }
        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyList<string>> GetBrandAsync()
        {
           return await context.products.Select(i => i.Brand).Distinct().ToListAsync();
        }

        public async Task<IReadOnlyList<string>> GetTypesAsync()
        {
            return await context.products.Select(i => i.Type).Distinct().ToListAsync();
        }
    }
}