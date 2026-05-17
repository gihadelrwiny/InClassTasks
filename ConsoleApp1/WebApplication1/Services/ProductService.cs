using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly ProductContext _context;
        public ProductService(ProductContext context)
        {
            _context = context;
        }
        public void AddProduct(string Name, decimal Price, int quantity, string Category)
        {
            Product product = new Product()
            {
                Name = Name,
                Price = Price,
                quantity = quantity,
                Category = Category
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void GetAllProducts()
        {
            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.quantity}");
            }
        }
        public void GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void GetByCategory(string category)
        {
            var product = _context.Products.FirstOrDefault(x => x.Category == category);
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.quantity}");

        }
        public void UpdatePrice(int id,decimal price)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Price = price;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void DeleteById(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }


    }
}
