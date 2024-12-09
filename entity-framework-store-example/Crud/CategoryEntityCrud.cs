using entity_framework_store_example.Crud.Shared;
using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities;

namespace entity_framework_store_example.Crud;

public class CategoryEntityCrud(StoreDbContext context) : EntityCrud<CategoryEntity>(context)
{
	private readonly StoreDbContext _context = context;

	public override void Create()
	{
		ClearScreen("Create");

		Console.Write("Enter category name: ");
		var newCategoryName = Console.ReadLine();

		var newCategory = new CategoryEntity
		{
			Name = newCategoryName ?? "New category name"
		};
		
		_context.Categories.Add(newCategory);
		_context.SaveChanges();
		
		WaitForKey();
	}

	public override void Update()
	{
		ClearScreen("Update");

		Console.Write("Enter category Id: ");
		
		var input = Console.ReadLine();

		if (input == null || !Guid.TryParse(input, out var id))
		{
			Update();
			
			return;
		}
		
		var categoryEntity = _context.Categories.Find(id);

		if (categoryEntity == null)
		{
			Console.WriteLine("404 - Category not found");
			
			WaitForKey();

			return;
		}

		Console.WriteLine(categoryEntity);

		Console.Write("Enter new category name: ");
		input = Console.ReadLine();
		
		categoryEntity.Name = input ?? categoryEntity.Name;
		
		_context.Categories.Update(categoryEntity);
		_context.SaveChanges();
		
		WaitForKey();
	}
}