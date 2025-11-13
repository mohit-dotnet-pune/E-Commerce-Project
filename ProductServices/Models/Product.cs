using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(500)]
        public string? ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public int CategoryId {  get; set; } 
    }
}
