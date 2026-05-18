using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OrderService
    {
        private readonly ProductContext _context;
        public OrderService(ProductContext context)
        {
            _context = context;
        }
        public void GetOrderWithDetails()
        {
            var orders = _context.Orders.Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.product)
                .AsNoTracking()
                .ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Customer: {order.Customer.Name}");

                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine(
                        $"Product: {item.product.Name} " +
                        $"Quantity: {item.quantity}");
                }

            }

        }
        public void GetPagedOrder(int pageindex, int pageSize)
        {
            var orders = _context.Orders
                .OrderBy(o => o.CreatedAt)
                .Skip(pageindex * pageSize)
                .Take(pageSize)
                .ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(
            $"Order Id: {order.Id} " +
            $"Created At: {order.CreatedAt}");
            }


        }
        public void GetOrderByCustomerCity(string city)
        {
            var orders = _context.Orders
                .Where(o => o.Customer.city == city)
                .ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(
            $"Order Id: {order.Id} " +
            $"Created At: {order.CreatedAt}");
            }

        }
        public void GetOrderSummary()
        {
            var summary = new OrderSummaryDTO
            {
                TotalOrders = _context.Orders.Count(),

                TotalRevenue = _context.OrderItems
          .Sum(oi => oi.quantity * oi.product.Price),

                AverageRevenue = _context.Orders
          .Select(o => o.OrderItems
              .Sum(oi => oi.quantity * oi.product.Price))
          .Average()
            };

            Console.WriteLine($"Total Orders: {summary.TotalOrders}");

            Console.WriteLine($"Total Revenue: {summary.TotalRevenue}");

            Console.WriteLine($"Average Revenue: {summary.AverageRevenue}");
        }
    }
}
