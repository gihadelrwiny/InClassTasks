using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000 },
            new Product { Id = 2, Name = "Phone", Price = 8000 }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Id = products.Max(s => s.Id) + 1,
            };
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new { Id = product.Id }, product);
        }
}}
