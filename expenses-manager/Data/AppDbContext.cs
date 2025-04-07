using expenses_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace expenses_manager.Data;

public class AppDbContext : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ExpenseEntity> Expenses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Database=ExpensesManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        
        base.OnConfiguring(optionsBuilder);
    }
}