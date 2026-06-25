using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
