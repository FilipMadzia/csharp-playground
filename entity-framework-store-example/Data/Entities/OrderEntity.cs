using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Data.Entities;

public class OrderEntity : Entity
{
	public DateTime OrderDate { get; private set; } = DateTime.Now;
	
	public Guid CustomerId { get; set; }
	public CustomerEntity Customer { get; set; } = null!;

	public ICollection<ProductEntity> Products { get; set; } = [];
	
	public override string ToString() => $"{Id}\t{OrderDate}\t{CustomerId}";
}