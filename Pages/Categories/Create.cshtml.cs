using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using commerceProjet.Data;
using commerceProjet.Models;

namespace commerceProjet.Pages.Categories
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
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
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

                // Renvoyer la page avec les erreurs
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
