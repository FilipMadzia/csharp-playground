using entity_framework_store_example.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_store_example.Data;

public class DataSeeder(ModelBuilder modelBuilder)
{
	public void SeedCategories()
	{
		var categories = new List<CategoryEntity>
		{
			new() { Name = "T-Shirts" },
			new() { Name = "Shoes" },
			new() { Name = "Jackets" },
			new() { Name = "Hats" }
		};
		
		modelBuilder.Entity<CategoryEntity>().HasData(categories);
	}
	
	public void SeedCustomers()
	{
		var customers = new List<CustomerEntity>
		{
			new() { FirstName = "John", LastName = "Williams" },
			new() { FirstName = "Max", LastName = "Smith" },
			new() { FirstName = "Alex", LastName = "Adams" },
			new() { FirstName = "Derry", LastName = "Collins" }
		};
		
		modelBuilder.Entity<CustomerEntity>().HasData(customers);
	}
}