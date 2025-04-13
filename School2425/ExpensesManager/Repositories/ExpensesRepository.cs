using System.Collections.Generic;
using System.Linq;
using ExpensesManager.Data;
using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Repositories;

public class ExpensesRepository : Repository<ExpenseEntity>
{
	readonly AppDbContext _context;

	public ExpensesRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
	
	public ICollection<ExpenseEntity> GetAllIncluding()
	{
		return _context.Expenses
			.Include(x => x.Category)
			.OrderByDescending(x => x.Date)
			.ThenByDescending(x => x.Id)
			.ToList();
	}

	public ExpenseEntity? GetByIdIncluding(int id)
	{
		return _context.Expenses
			.Include(x => x.Category)
			.FirstOrDefault(x => x.Id == id);
	}
}