using entity_framework_store_example.Crud.Shared;
using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities;

namespace entity_framework_store_example.Crud;

public class OrderEntityCrud(StoreDbContext context) : EntityCrud<OrderEntity>(context)
{
	private readonly StoreDbContext _context = context;

	public override void Create()
	{
		ClearScreen("Create");

		Console.Write("Enter customer Id: ");
		if (!Guid.TryParse(Console.ReadLine(), out var customerId))
		{
			Create();

			return;
		}

		var orderEntity = new OrderEntity
		{
			CustomerId = customerId,
			Products = GetProducts()
		};
		
		_context.Orders.Add(orderEntity);
		_context.SaveChanges();
		
		WaitForKey();
	}

	public override void Update()
	{
		throw new NotImplementedException();
	}

	private List<ProductEntity> GetProducts()
	{
		var products = new List<ProductEntity>();

		while (true)
		{
			Console.Write("Enter product Id (\"exit\" to exit): ");
			
			var input = Console.ReadLine();

			if (input == "exit")
				break;

			if (input == null || !Guid.TryParse(input, out var id))
				continue;
			
			var product = _context.Products.Find(id);
			
			if (product == null)
				continue;
			
			products.Add(product);
		}
		
		return products;
	}
}