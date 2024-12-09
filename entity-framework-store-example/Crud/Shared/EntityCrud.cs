using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Crud.Shared;

public abstract class EntityCrud<T>(StoreDbContext context) : IEntityCrud where T : Entity
{
	public void SelectAction()
	{
		switch (GetActionInt())
		{
			case 1:
				DisplayAll();
				break;
			case 2:
				DisplayById();
				break;
			case 3:
				DeleteById();
				break;
			case 4:
				Create();
				break;
			case 5:
				Update();
				break;
			case 6:
				return;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private int GetActionInt()
	{
		ClearScreen();
		
		Console.WriteLine("Select action\n" +
		                  $"1. {nameof(DisplayAll)}\n" +
		                  $"2. {nameof(DisplayById)}\n" +
		                  $"3. {nameof(DeleteById)}\n" +
		                  $"4. {nameof(Create)}\n" +
		                  $"5. {nameof(Update)}\n" +
		                  "6. exit");

		Console.Write("Action: ");

		var input = Console.ReadLine();
		
		if (input == null || !int.TryParse(input, out var actionInt))
			actionInt = GetActionInt();
		
		if (actionInt < 1 || actionInt > 6)
			actionInt = GetActionInt();
		
		return actionInt;
	}

	public void DisplayAll()
	{
		ClearScreen("Display all");
		
		var entities = context.Set<T>().OrderBy(x => x.Created).ToList();
		
		entities.ForEach(Console.WriteLine);
		
		WaitForKey();
	}

	public void DisplayById()
	{
		ClearScreen("Display by ID");

		Console.Write("Enter entity ID: ");
		
		var input = Console.ReadLine();

		if (input == null || !Guid.TryParse(input, out var id))
		{
			DisplayById();
			
			return;
		}
		
		var entity = context.Set<T>().Find(id);

		if (entity == null)
		{
			Console.WriteLine("404 - Entity not found");
			
			WaitForKey();
			
			return;
		}

		Console.WriteLine(entity);
		
		WaitForKey();
	}

	public void DeleteById()
	{
		ClearScreen("Delete by ID");
		
		Console.Write("Enter entity ID: ");
		
		var input = Console.ReadLine();

		if (input == null || !Guid.TryParse(input, out var id))
		{
			DeleteById();
			
			return;
		}
		
		var entity = context.Set<T>().Find(id);

		if (entity == null)
		{
			Console.WriteLine("404 - Entity not found");
			
			WaitForKey();

			return;
		}
		
		context.Set<T>().Remove(entity);
		context.SaveChanges();
		
		WaitForKey();
	}

	public abstract void Create();
	
	public abstract void Update();

	protected void ClearScreen(string? additionalMessage = null)
	{
		Console.Clear();

		Console.WriteLine($"CRUD - {typeof(T).Name} {additionalMessage}");
	}

	protected void WaitForKey()
	{
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey();
	}
}