using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coroian_Carmen_Ioana_Lab2.Models;
using Coroian_Carmen_Ioana_Lab2.Models.ViewModels;

namespace Coroian_Carmen_Ioana_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Coroian_Carmen_Ioana_Lab2Context _context;

        public IndexModel(Coroian_Carmen_Ioana_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(i => i.Book)
                        .ThenInclude(i => i.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();

               
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
}