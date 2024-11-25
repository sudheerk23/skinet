using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public required string Name { get; set; }  = string.Empty;
        [Required]
        public required string Description { get; set; } = string.Empty;
        [Range(0.01,double.MaxValue,ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required]
        public required string PictureUrl { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string Brand { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "Quantity in stock must be greater than 1")]
        public int QuantityInStock { get; set; }
    }
}