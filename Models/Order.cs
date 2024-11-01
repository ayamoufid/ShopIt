using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace commerceProjet.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
