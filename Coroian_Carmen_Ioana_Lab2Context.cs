using Microsoft.EntityFrameworkCore;

public class Coroian_Carmen_Ioana_Lab2Context(DbContextOptions<Coroian_Carmen_Ioana_Lab2Context> options) : DbContext(options)
{
    public DbSet<Coroian_Carmen_Ioana_Lab2.Models.Book> Book { get; set; } = default!;

    // Add DbSet for Publisher so _context.Publisher is available in pages
    public DbSet<Coroian_Carmen_Ioana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
}
