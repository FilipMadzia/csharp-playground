using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Data.Entities;

public class OrderProductEntity : Entity
{
	public Guid OrderId { get; set; }
	public OrderEntity Order { get; set; } = null!;
	
	public Guid ProductId { get; set; }
	public ProductEntity Product { get; set; } = null!;
}