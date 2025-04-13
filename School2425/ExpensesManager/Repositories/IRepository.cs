using System.Collections.Generic;
using ExpensesManager.Models;

namespace ExpensesManager.Repositories;

public interface IRepository<T> where T : Entity
{
	ICollection<T> GetAll();
	T? GetById(int id);
	void Add(T entity);
	void Update(T entity);
	void Delete(T entity);
}