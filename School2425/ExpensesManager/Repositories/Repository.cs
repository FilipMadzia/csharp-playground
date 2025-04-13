using System.Collections.Generic;
using System.Linq;
using ExpensesManager.Data;
using ExpensesManager.Models;

namespace ExpensesManager.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
	readonly AppDbContext _context;

	public Repository(AppDbContext context)
	{
		_context = context;
	}
	
	public ICollection<T> GetAll() => _context.Set<T>().OrderBy(x => x.Id).ToList();

	public T? GetById(int id) => _context.Set<T>().Find(id);

	public void Add(T entity)
	{
		_context.Set<T>().Add(entity);
		_context.SaveChanges();
	}

	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
		_context.SaveChanges();
	}

	public void Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
		_context.SaveChanges();
	}
}