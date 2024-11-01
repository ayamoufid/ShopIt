using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace commerceProjet.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
