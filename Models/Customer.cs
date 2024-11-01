using System.ComponentModel.DataAnnotations;

namespace commerceProjet.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
