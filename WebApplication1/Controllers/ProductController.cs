using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.DTO;
using WebApplication1.interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly AppSettings _settings;

        public ProductController(
            IProductService productService,
            IOptions<AppSettings> options)
        {
            _productService = productService;
            _settings = options.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                ApiVersion = _settings.ApiVersion,
                Products = _productService.GetAll()
            });
        }
        [Authorize(Policy = "CanManageProducts")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            return Ok(product);

        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var product = _productService.CreateProduct(dto);
            return CreatedAtAction(
         nameof(GetById),
         new { id = product.Id },
         product);
        }

            
    }
}
