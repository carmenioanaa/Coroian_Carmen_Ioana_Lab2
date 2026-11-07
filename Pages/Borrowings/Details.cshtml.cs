using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coroian_Carmen_Ioana_Lab2.Models;

namespace Coroian_Carmen_Ioana_Lab2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Coroian_Carmen_Ioana_Lab2Context _context;
    public DetailsModel(Coroian_Carmen_Ioana_Lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Book)
            .Include(b => b.Member).FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        else
        {
            Borrowing = borrowing;
        }

        return Page();
    }
}
