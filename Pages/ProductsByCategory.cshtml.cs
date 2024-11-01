using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commerceProjet.Models;
using commerceProjet.Data;
using Microsoft.AspNetCore.Mvc;

namespace commerceProjet.Pages
{
    public class ProductsByCategoryModel : PageModel
    {
        private readonly commerceProjetContext _context;

        public ProductsByCategoryModel(commerceProjetContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync(int categoryId)
        {
            Products = await _context.Product
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public IActionResult OnPostAddToCart(int productId, int stockQuantity)
        {
            var product = _context.Product.Find(productId); 
            if (product != null && product.StockQuantity > 0)
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
                var cartItem = cart.FirstOrDefault(x => x.ProductId == productId);

                if (cartItem == null)
                {
                    cart.Add(new CartItem { ProductId = productId, Price = product.Price, Quantity = 1 });
                }
                else
                {
                    if (cartItem.Quantity < stockQuantity)
                    {
                        cartItem.Quantity++;
                    }
                }

                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
            return RedirectToPage();
        }
    }
}