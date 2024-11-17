using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoredContextSeed
    {
        public async static Task SeedAsync(StoreContent context)
        {
            if(!context.products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                var list = JsonSerializer.Deserialize<List<Product>>(productsData);

                if(list == null) return;

                context.products.AddRange(list);
                await context.SaveChangesAsync();
            }
        }
    }
}