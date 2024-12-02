using System.ComponentModel.DataAnnotations;
using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Data.Entities;

public class ProductEntity : Entity
{
	[MaxLength(64)]
	public string Name { get; set; } = string.Empty;
	public decimal Price { get; set; }
	[MaxLength(1024)]
	public string Description { get; set; } = string.Empty;
	
	public Guid CategoryId { get; set; }
	public CategoryEntity Category { get; set; } = null!;

	public ICollection<OrderProductEntity> OrderProducts { get; set; } = [];
}