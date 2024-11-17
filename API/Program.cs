using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContent>(obj => {
    obj.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository,ProductRepository>(); 
 
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContent>();
    await context.Database.MigrateAsync();
    await StoredContextSeed.SeedAsync(context);
}catch(Exception ex)
{
    System.Console.WriteLine(ex.Message);
}

app.Run();
