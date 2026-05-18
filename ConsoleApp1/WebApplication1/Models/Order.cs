using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int Id{ get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItems> OrderItems { get; set; }
        = new List<OrderItems>();

    }
}
