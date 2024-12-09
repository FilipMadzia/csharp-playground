using entity_framework_store_example.Crud.Shared;
using entity_framework_store_example.Data;
using entity_framework_store_example.Data.Entities;

namespace entity_framework_store_example.Crud;

public class CustomerEntityCrud(StoreDbContext context) : EntityCrud<CustomerEntity>(context)
{
	private readonly StoreDbContext _context = context;

	public override void Create()
	{
		ClearScreen("Create");

		Console.Write("Enter customer first name: ");
		var firstName = Console.ReadLine();

		Console.Write("Enter customer last name: ");
		var lastName = Console.ReadLine();

		var newCustomer = new CustomerEntity
		{
			FirstName = firstName ?? "New first name",
			LastName = lastName ?? "New last name",
		};
		
		_context.Customers.Add(newCustomer);
		_context.SaveChanges();
		
		WaitForKey();
	}

	public override void Update()
	{
		ClearScreen("Update");
		
		Console.Write("Enter customer Id: ");
		
		var input = Console.ReadLine();

		if (input == null || !Guid.TryParse(input, out var id))
		{
			Update();
			
			return;
		}

		var customerEntity = _context.Customers.Find(id);
		
		if (customerEntity == null)
		{
			Console.WriteLine("404 - Customer not found");
			
			WaitForKey();

			return;
		}

		Console.WriteLine(customerEntity);

		Console.Write("Enter new customer first name: ");
		input = Console.ReadLine();
		
		customerEntity.FirstName = input ?? customerEntity.FirstName;

		Console.WriteLine("Enter new customer last name: ");
		input = Console.ReadLine();
		
		customerEntity.LastName = input ?? customerEntity.LastName;
		
		_context.Customers.Update(customerEntity);
		_context.SaveChanges();
		
		WaitForKey();
	}
}