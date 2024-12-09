using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities;

namespace entity_framework_store_example;

class Program
{
	static void Main(string[] args)
	{
		Start();
	}

	static void Start()
	{
		Console.Clear();
		using var context = new StoreDbContext();
		
		context.Database.EnsureCreated();

		Console.WriteLine("Wybierz tabelę\n" +
		                  "1. Produkty\n" +
		                  "2. Kategorie\n" +
		                  "3. Klienci\n" +
		                  "4. Zamówienia");

		Console.Write("Tabela: ");
		
		var input = Console.ReadLine();

		if (input == null)
			throw new ArgumentNullException(nameof(input));

		switch (int.Parse(input))
		{
			case 1:
				HandleProducts(context);
				break;
			case 2:
				HandleCategories(context);
				break;
			case 3:
				HandleCustomers(context);
				break;
			case 4:
				HandleOrders(context);
				break;
		}
	}

	static void HandleProducts(StoreDbContext context)
	{
		Console.Clear();
		Console.WriteLine("Produkty");
	}
	
	static void HandleCategories(StoreDbContext context)
	{
		Console.Clear();
		Console.WriteLine("Kategorie");
		
		Console.WriteLine("Wybierz akcję:\n" +
		                  "1. Odczyt wszystkich\n" +
		                  "2. Odczyt po ID\n" +
		                  "3. Usunięcie po ID\n" +
		                  "4. Aktualizacja po ID\n" +
		                  "5. Dodawanie");

		Console.Write("Akcja: ");
		var input = Console.ReadLine();
		
		if (input == null)
			throw new ArgumentNullException(nameof(input));

		switch (int.Parse(input))
		{
			case 1:
				var categories = context.Categories.ToList();

				Console.Clear();
				Console.WriteLine("Kategorie - odczyt wszystkich");
				categories.ForEach(Console.WriteLine);
				
				break;
			case 2:
				Console.Clear();
				Console.WriteLine("Kategorie - odczyt po ID");
				Console.Write("Podaj ID kategorii: ");
				
				var id = Console.ReadLine();
				
				if (id == null)
					throw new ArgumentNullException(nameof(id));
				
				var category = context.Categories.First(x => x.Id == new Guid(id));

				Console.WriteLine(category);
				
				break;
			case 3:
				Console.Clear();
				Console.WriteLine("Kategorie - usunięcie po ID");
				Console.Write("Podaj ID kategorii: ");
				
				id = Console.ReadLine();
				
				if (id == null)
					throw new ArgumentNullException(nameof(id));
				
				var categoryToRemove = context.Categories.First(x => x.Id == new Guid(id));
				context.Categories.Remove(categoryToRemove);
				context.SaveChanges();
				
				break;
			case 4:
				Console.Clear();
				Console.WriteLine("Kategorie - aktualizacja po ID");
				Console.Write("Podaj ID kategorii: ");
				
				id = Console.ReadLine();
				
				if (id == null)
					throw new ArgumentNullException(nameof(id));
				
				category = context.Categories.First(x => x.Id == new Guid(id));

				Console.WriteLine(category);
				
				Console.Write("Podaj nową nazwę kategorii: ");
				var newCategoryName = Console.ReadLine();
				
				if (newCategoryName == null)
					throw new ArgumentNullException(nameof(newCategoryName));
				
				category.Name = newCategoryName;
				
				context.Categories.Update(category);
				context.SaveChanges();
				
				break;
			case 5:
				var newCategory = new CategoryEntity();
				
				Console.Clear();
				Console.WriteLine("Kategorie - dodawanie");
				Console.Write("Podaj nazwę kategorii: ");
				var newCategoryName1 = Console.ReadLine();
				
				if (newCategoryName1 == null)
					throw new ArgumentNullException(nameof(newCategoryName1));
				
				newCategory.Name = newCategoryName1;
				
				context.Categories.Add(newCategory);
				context.SaveChanges();
				
				break;
		}

		End();
	}
	
	static void HandleCustomers(StoreDbContext context)
	{
		Console.Clear();
		Console.WriteLine("Klienci");
	}
	
	static void HandleOrders(StoreDbContext context)
	{
		Console.Clear();
		Console.WriteLine("Zamówienia");
	}

	static void End()
	{
		Console.WriteLine("Wciśnij dowolny klawisz...");
		Console.ReadKey();
		Start();
	}
}