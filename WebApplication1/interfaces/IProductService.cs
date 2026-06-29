using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        public ProductDto CreateProduct(CreateProductDto dto);
    }
}
