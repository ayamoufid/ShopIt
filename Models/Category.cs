using System.ComponentModel.DataAnnotations;

namespace commerceProjet.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageCat { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
