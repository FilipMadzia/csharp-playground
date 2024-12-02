namespace entity_framework_store_example.Data.Entities.Shared;

public class Entity
{
	public Guid Id { get; private set; } = Guid.NewGuid();
	public DateTime Created { get; private set; } = DateTime.Now;
	public DateTime? Modified { get; set; }
}