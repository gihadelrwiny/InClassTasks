using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string city { get; set; }
        public List<Order> Orders { get; set; }
          = new List<Order>();
    }
}
