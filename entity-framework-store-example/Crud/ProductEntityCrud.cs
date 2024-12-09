using entity_framework_store_example.Crud.Shared;
using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities;

namespace entity_framework_store_example.Crud;

public class ProductEntityCrud(StoreDbContext context) : EntityCrud<ProductEntity>(context)
{
	private readonly StoreDbContext _context = context;

	public override void Create()
	{
		ClearScreen("Create");

		Console.Write("Enter product name: ");
		var name = Console.ReadLine();
		
		Console.Write("Enter product price: ");
		var price = decimal.Parse(Console.ReadLine() ?? "0");
		
		Console.Write("Enter product description: ");
		var description = Console.ReadLine();
		
		Console.Write("Enter category Id: ");
		if (!Guid.TryParse(Console.ReadLine(), out var categoryId))
		{
			Create();

			return;
		}

		var productEntity = new ProductEntity 
		{
			Name = name ?? "New product name",
			Price = price,
			Description = description ?? "New product description",
			CategoryId = categoryId
		};
		
		_context.Products.Add(productEntity);
		_context.SaveChanges();
		
		WaitForKey();
	}

	public override void Update()
	{
		throw new NotImplementedException();
	}
}