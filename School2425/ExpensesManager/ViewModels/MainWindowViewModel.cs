using System.Collections.ObjectModel;
using System.Linq;
using ExpensesManager.Data;
using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.ViewModels;

public class MainWindowViewModel
{
	public ObservableCollection<ExpenseEntity> Expenses { get; set; }

	private readonly AppDbContext _context;

	public MainWindowViewModel(AppDbContext context)
	{
		_context = context;
		
		var expenses = _context.Expenses.Include(x => x.Category);
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);
	}
}