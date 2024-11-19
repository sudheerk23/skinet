using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> repo) : Controller
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllProducts(string? brand, string? type,string? sort)
        {
            var products = new ProductFilterSortSpecification(brand,type,sort);
            var list = await repo.ListAsyc(products);
            return Ok(list);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetAllProducts(int id)
        {
            var data = await repo.GetByIdAsync(id);
            if (data == null) return NotFound();
            return data;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            repo.Add(product);

            if(await repo.SaveChangesAsyc())
            {
                return CreatedAtAction("Product Added",product);
            }
            return BadRequest("Failed to Create Product");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var data = await repo.GetByIdAsync(id);
            if (data == null) return NoContent();

            repo.Delete(data);
            if(await repo.SaveChangesAsyc())
            {
                return NoContent();
            }
            return BadRequest("Failed to delete product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,Product product)
        {
            if(product.Id != id || !repo.Exists(product.Id)) return BadRequest("Id not matched");

            repo.Update(product);
            if(await repo.SaveChangesAsyc())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product");
        }

    
        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = new BrandListSpecifications();

            return Ok(await repo.ListAsyc(brands));
        }
        
        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var types = new TypeListSpecificaions();
            
            return Ok(await repo.ListAsyc(types));
        }

    }
}