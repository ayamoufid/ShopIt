using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using commerceProjet.Data;
using commerceProjet.Models;

namespace commerceProjet.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly commerceProjet.Data.commerceProjetContext _context;

        public IndexModel(commerceProjet.Data.commerceProjetContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.Category).ToListAsync();
        }
    }
}
