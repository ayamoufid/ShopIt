using commerceProjet.Data;
using commerceProjet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace commerceProjet.Services
{
    public class ProductService
    {
        private readonly commerceProjetContext _context;

        public ProductService(commerceProjetContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Product
                .Include(p => p.Category) // Include related category if necessary
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Product
                .Where(p => p.Category.Id == categoryId)
                .ToListAsync();
        }
    }
}