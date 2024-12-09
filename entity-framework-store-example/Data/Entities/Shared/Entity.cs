using System.ComponentModel.DataAnnotations;

namespace entity_framework_store_example.Data.Entities.Shared;

public class Entity
{
	[Key]
	public Guid Id { get; private set; } = Guid.NewGuid();
	public DateTime Created { get; private set; } = DateTime.Now;
	public DateTime? Modified { get; set; }
	
	public override string ToString() => $"{Id}\t{Created}\t{Modified}";
}