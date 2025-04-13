using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Data;

public class AppDbContext : DbContext
{
	public DbSet<ExpenseEntity> Expenses => Set<ExpenseEntity>();
	public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Database=ExpensesManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
		
		base.OnConfiguring(optionsBuilder);
	}
}