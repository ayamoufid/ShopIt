using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using commerceProjet.Data;
using commerceProjet.Models;

namespace commerceProjet.Pages.OrderDetails
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
        ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        public List<string> ValidationErrors { get; set; } = new List<string>();
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
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
                ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Name");
                ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
                // Renvoyer la page avec les erreurs
                return Page();
            }

            _context.OrderDetail.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
