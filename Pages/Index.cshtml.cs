// Pages/Index.cshtml.cs
using commerceProjet.Models;
using commerceProjet.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace commerceProjet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CategoryService _categoryService;

        public IndexModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; set; }
        public string SearchTerm { get; set; }

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm;
            Categories = await _categoryService.GetAllCategoriesAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Categories = Categories.FindAll(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
        }


    }
}
