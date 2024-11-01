using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using commerceProjet.Data;
using commerceProjet.Models;
using Microsoft.EntityFrameworkCore;

namespace commerceProjet.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly commerceProjet.Data.commerceProjetContext _context;

        public CreateModel(commerceProjet.Data.commerceProjetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }
        /*public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _context.Category.ToListAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return Page();
        }*/



        [BindProperty]
        public Product Product { get; set; } = default!;
        public List<string> ValidationErrors { get; set; } = new List<string>();
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"CategoryId reçu: {Product.CategoryId}");
            if (Product.CategoryId == 0)
            {
                Console.WriteLine("CategoryId est 0, ce qui n'est pas valide.");
                ModelState.AddModelError("Product.CategoryId", "La catégorie est requise.");
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
                return Page();
            }

            var categorie = await _context.Category.FindAsync(Product.CategoryId);
            if (categorie == null)
            {
                Console.WriteLine($"Aucune catégorie trouvée pour l'ID: {Product.CategoryId}");
                ModelState.AddModelError("Product.CategoryId", "Catégorie invalide");
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
                return Page();
            }
            Product.Category = categorie;

            if (!ModelState.IsValid)
            {
                // Collecter les erreurs de validation du ModelState
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    var errors = value.Errors;
                    foreach (var error in errors)
                    {
                        // Ajouter chaque message d'erreur à la liste
                        ValidationErrors.Add($"Champ: {modelStateKey} - Erreur: {error.ErrorMessage}");
                    }
                }
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
                // Renvoyer la page avec les erreurs
                return Page();
            }
            
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
