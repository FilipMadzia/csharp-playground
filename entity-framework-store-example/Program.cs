using entity_framework_store_example.Data;

namespace entity_framework_store_example;

class Program
{
	static void Main(string[] args)
	{
		using var context = new StoreDbContext();
		
		context.Database.EnsureCreated();
		
		
	}
}