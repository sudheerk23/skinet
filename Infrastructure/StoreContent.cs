using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure;

public class StoreContent(DbContextOptions dbContext) : DbContext(dbContext)
{

    public DbSet<Product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        base.OnModelCreating(optionsBuilder);
        optionsBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigurations).Assembly);
        
    }

}
