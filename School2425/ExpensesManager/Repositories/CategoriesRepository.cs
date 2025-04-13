using System.Collections.Generic;
using System.Linq;
using ExpensesManager.Data;
using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Repositories;

public class CategoriesRepository : Repository<CategoryEntity>
{
	readonly AppDbContext _context;

	public CategoriesRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}

	public ICollection<CategoryEntity> GetAllIncluding()
	{
		return _context.Categories
			.Include(x => x.Expenses)
			.OrderBy(x => x.Id)
			.ToList();
	}

	public CategoryEntity? GetByIdIncluding(int id)
	{
		return _context.Categories
			.Include(x => x.Expenses)
			.FirstOrDefault(x => x.Id == id);
	}

	public CategoryEntity? GetByName(string name)
	{
		return _context.Categories.FirstOrDefault(x => x.Name == name);
	}
}