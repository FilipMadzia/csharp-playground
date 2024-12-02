using System.ComponentModel.DataAnnotations;
using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Data.Entities;

public class CustomerEntity : Entity
{
	[MaxLength(64)]
	public string FirstName { get; set; } = string.Empty;
	[MaxLength(64)]
	public string LastName { get; set; } = string.Empty;

	public ICollection<OrderEntity> Orders { get; set; } = [];
}