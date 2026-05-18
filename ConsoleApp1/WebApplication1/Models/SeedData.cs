using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class SeedData
    {
        public static void Initialize(ProductContext context)
        {
            if (context.Customers.Any() || context.Products.Any())
                return;

            // ---------------- Customers ----------------
            var customers = new List<Customer>
            {
                new Customer { Name = "Ahmed", city = "Cairo" },
                new Customer { Name = "Mona", city = "Alex" },
                new Customer { Name = "Omar", city = "Giza" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();

            // ---------------- Products ----------------
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 20000, quantity = 10, Category = "Electronics" },
                new Product { Name = "Phone", Price = 10000, quantity = 20, Category = "Electronics" },
                new Product { Name = "Book", Price = 200, quantity = 50, Category = "Education" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            // ---------------- Orders ----------------
            var orders = new List<Order>
            {
                new Order
                {
                    CreatedAt = DateTime.Now,
                    CustomerId = customers[0].Id
                },
                new Order
                {
                    CreatedAt = DateTime.Now,
                    CustomerId = customers[1].Id
                }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();

            // ---------------- OrderItems ----------------
            var orderItems = new List<OrderItems>
            {
                new OrderItems
                {
                    OrderId = orders[0].Id,
                    ProductId = products[0].ProductId,
                    quantity = 1
                },
                new OrderItems
                {
                    OrderId = orders[0].Id,
                    ProductId = products[2].ProductId,
                    quantity = 3
                },
                new OrderItems
                {
                    OrderId = orders[1].Id,
                    ProductId = products[1].ProductId,
                    quantity = 2
                }
            };

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();
        }
    }
}