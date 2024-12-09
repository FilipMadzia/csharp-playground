using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using entity_framework_store_example.Data.Entities.Shared;

namespace entity_framework_store_example.Data.Entities;

public class CategoryEntity : Entity
{
	[MaxLength(64)]
	public string Name { get; set; } = string.Empty;

	public ICollection<ProductEntity> Products { get; set; } = [];

	public override string ToString() => $"{Id}\t{Name}";
}