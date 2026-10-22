using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coroian_Carmen_Ioana_Lab2.Models;

namespace Coroian_Carmen_Ioana_Lab2.Pages.CategoryPages;

public class CreateModel : PageModel
{
    private readonly Coroian_Carmen_Ioana_Lab2Context _context;

    public CreateModel(Coroian_Carmen_Ioana_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Category Category { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Category.Add(Category);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
