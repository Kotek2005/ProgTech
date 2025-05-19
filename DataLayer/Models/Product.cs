using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public int StockQuantity { get; set; }
    }
} 