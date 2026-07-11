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
       
        /// <summary>Get All Products</summary>
        ///
        /// <returns>The product details if found</returns>
        /// <response code="200">All products returned</response>
        /// <response code="401">Authentication required</response>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                ApiVersion = _settings.ApiVersion,
                Products = _productService.GetAll()
            });
        }
        /// <summary>Get a product by its ID</summary>
        /// <param name="id">The unique product identifier</param>
        /// <returns>The product details if found</returns>
        /// <response code="200">Product found and returned</response>
        /// <response code="404">Product not found</response>
        /// <response code="403">Forbidden</response>
        [Authorize(Policy = "CanManageProducts")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            
          

            return Ok(product);

        }
        [Authorize]
        [HttpPost]
        /// <summary>Create a new product</summary>
        /// <returns>The created product details</returns>
        /// <param name="dto">The product information to create</param>
        /// <response code="201">Product created successfully</response>
        /// <response code="400">Invalid product data</response>
        /// <response code="401">Authentication required</response>
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
