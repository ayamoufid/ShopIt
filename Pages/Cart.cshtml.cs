using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commerceProjet.Models;
using commerceProjet.Data;
using Microsoft.AspNetCore.Mvc;



    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void OnGet()
        {
            CartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();
        }

        public IActionResult OnPostUpdateCart(Dictionary<int, int> quantities, int? remove)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            // Supprimer un article
            if (remove.HasValue)
            {
                cart.RemoveAll(item => item.ProductId == remove.Value);
            }
            else
            {
                // Modifier les quantités
                foreach (var kvp in quantities)
                {
                    var item = cart.FirstOrDefault(x => x.ProductId == kvp.Key);
                    if (item != null)
                    {
                        int stockQuantity = GetStockQuantity(item.ProductId);

                        if (kvp.Value <= stockQuantity)
                        {
                            item.Quantity = kvp.Value; // Met à jour la quantité
                        }
                    }
                }
            }

            // Sauvegarder les modifications dans la session
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return RedirectToPage();
        }

        // Méthode fictive pour obtenir la quantité en stock d'un produit
        private int GetStockQuantity(int productId)
        {
            return 2;
        }

        public IActionResult OnPostClearCart()
        {
            if (HttpContext.Session.TryGetValue("cart", out _))
            {
                HttpContext.Session.SetString("cart", "[]");
            }

            return RedirectToPage();
        }
    }