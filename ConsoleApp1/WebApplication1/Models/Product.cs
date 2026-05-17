using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; } = decimal.Zero;
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int quantity { get; set; }
        public string Category { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
