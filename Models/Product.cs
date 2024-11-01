using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace commerceProjet.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; } 
        public string Image { get; set; }
        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
