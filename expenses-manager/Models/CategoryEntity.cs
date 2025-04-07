namespace expenses_manager.Models;

public class CategoryEntity : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColorHex { get; set; }
    
    public ICollection<ExpenseEntity> Expenses { get; set; }
}