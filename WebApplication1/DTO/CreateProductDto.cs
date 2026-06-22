using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Range(10,15000)]
        public decimal Price { get; set; }
    }
}
