using commerceProjet.Data;
using commerceProjet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace commerceProjet.Services
{
    public class CategoryService
    {
        private readonly commerceProjetContext _context;

        public CategoryService(commerceProjetContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category.Include(c => c.Products).ToListAsync();
        }
    }
}
