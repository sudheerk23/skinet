using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductRepository repo) : Controller
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllProducts(string? brand, string? type,string? sort)
        {
            return Ok(await repo.GetAllProductsAsync(brand,type,sort));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetAllProducts(int id)
        {
            var data = await repo.GetProductByIdAsync(id);
            if (data == null) return NotFound();
            return data;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            repo.CreateProduct(product);

            if(await repo.SaveChangesAsync())
            {
                return CreatedAtAction("Product Added",product);
            }
            return BadRequest("Failed to Create Product");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var data = await repo.GetProductByIdAsync(id);
            if (data == null) return NoContent();

            repo.DeleteProduct(data);
            if(await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Failed to delete product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,Product product)
        {
            if(product.Id != id || !repo.ProductExists(product.Id)) return BadRequest("Id not matched");

            repo.UpdateProduct(product);
            if(await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product");
        }

    
        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await repo.GetBrandAsync());
        }
        
        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await repo.GetTypesAsync());
        }

    }
}