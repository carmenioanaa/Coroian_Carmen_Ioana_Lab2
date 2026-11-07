using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coroian_Carmen_Ioana_Lab2.Models;

namespace Coroian_Carmen_Ioana_Lab2.Pages.Borrowings;

public class IndexModel : PageModel
{
    private readonly Coroian_Carmen_Ioana_Lab2Context _context;

    public IndexModel(Coroian_Carmen_Ioana_Lab2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Borrowing = await _context.Borrowing
            .Include(b => b.Book)
            .ThenInclude(b => b.Author)
            .Include(b => b.Member)
            .ToListAsync();
    }
}
