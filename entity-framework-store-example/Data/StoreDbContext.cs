using entity_framework_store_example.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_store_example.Data;

public class StoreDbContext : DbContext
{
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<CustomerEntity> Customers { get; set; }
	public DbSet<OrderEntity> Orders { get; set; }
	public DbSet<ProductEntity> Products { get; set; }
	
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Database=StoreDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ProductEntity>()
			.HasMany(x => x.Orders)
			.WithMany(x => x.Products)
			.UsingEntity("OrderProduct");
		
		var dataSeeder = new DataSeeder(modelBuilder);
		
		dataSeeder.SeedCategories();
		dataSeeder.SeedCustomers();
	}
}