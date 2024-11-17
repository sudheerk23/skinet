using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync(string? brand, string? type,string? sort);

        Task<Product?> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<string>> GetBrandAsync();
        Task<IReadOnlyList<string>> GetTypesAsync();


        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        bool ProductExists(int id);
        Task<bool> SaveChangesAsync();
    }
}