using WebApplication1.Shared.Exceptions;
using WebApplication1.interfaces;
using WebApplication1.Models;
using AutoMapper;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products =
        [
            new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Price = 25000, Stock = 20 },
            new Product { Id = 3, Name = "Mouse", Price = 500, Stock = 50 }
        ];
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<ProductDto> GetAll()
        {
            return _mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null) throw new NotFoundException($"Product {id} not found");
            return _mapper.Map<ProductDto>(product);

        }
        public ProductDto CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = products.Max(p => p.Id) + 1;
            product.Stock = 0;
            return _mapper.Map<ProductDto>(product);
        
        }

      
    }
}
