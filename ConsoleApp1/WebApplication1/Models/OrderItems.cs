using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class OrderItems
    {
        
        public int OrderId { get; set; }
        public int ProductId{ get; set; }
        public Product product;
        public Order order;

        public int quantity { get; set; }
    }
}
