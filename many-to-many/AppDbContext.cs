using many_to_many.Models;
using Microsoft.EntityFrameworkCore;

namespace many_to_many;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
    }
}