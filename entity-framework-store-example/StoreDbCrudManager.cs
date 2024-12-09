using entity_framework_store_example.Crud;
using entity_framework_store_example.Data;

namespace entity_framework_store_example;

public static class StoreDbCrudManager
{
	static StoreDbContext _context;
	public static void Run(StoreDbContext context)
	{
		_context = context;
		
		var running = true;

		while (running)
		{
			Console.Clear();

			switch (GetTableInt())
			{
				case 1:
					var categoryEntityCrud = new CategoryEntityCrud(_context);
					
					categoryEntityCrud.SelectAction();
					break;
				case 2:
					var customerEntityCrud = new CustomerEntityCrud(_context);
					
					customerEntityCrud.SelectAction();
					break;
				case 3:
					var orderEntityCrud = new OrderEntityCrud(_context);
					
					orderEntityCrud.SelectAction();
					break;
				case 4:
					var productEntityCrud = new ProductEntityCrud(_context);
					
					productEntityCrud.SelectAction();
					break;
				case 5:
					running = false;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	private static int GetTableInt()
	{
		Console.Clear();
		
		Console.WriteLine("Select table\n" +
		                  $"1. {nameof(_context.Categories)}\n" +
		                  $"2. {nameof(_context.Customers)}\n" +
		                  $"3. {nameof(_context.Orders)}\n" +
		                  $"4. {nameof(_context.Products)}\n" +
		                  "5. exit");

		Console.Write("Table: ");
		
		var input = Console.ReadLine();
		
		if (input == null || !int.TryParse(input, out var tableInt))
			tableInt = GetTableInt();
		
		if (tableInt < 1 || tableInt > 6)
			tableInt = GetTableInt();
		
		return tableInt;
	}
}