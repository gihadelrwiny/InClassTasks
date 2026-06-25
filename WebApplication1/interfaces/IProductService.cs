using WebApplication1.Models;

namespace WebApplication1.interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(int id);
    }
}
