namespace expenses_manager.Models;

public class ExpenseEntity : Entity
{
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public CategoryEntity Category { get; set; }
}