using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExpensesManager.Commands;
using ExpensesManager.Models;
using ExpensesManager.Repositories;

namespace ExpensesManager.ViewModels;

public class AddExpenseWindowViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	private string _name;
	private DateOnly _date;
	private decimal _amount;
	private CategoryEntity _category;

	public string Name
	{
		get => _name;
		set { _name = value; OnPropertyChanged(); }
	}

	public DateOnly Date
	{
		get => _date;
		set { _date = value; OnPropertyChanged(); }
	}

	public decimal Amount
	{
		get => _amount;
		set { _amount = value; OnPropertyChanged(); }
	}

	public CategoryEntity Category
	{
		get => _category;
		set { _category = value; OnPropertyChanged(); }
	}

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		AddExpenseCommand?.RaiseCanExecuteChanged();
	}

	public ICollection<CategoryEntity> Categories { get; set; }
	public RelayCommand AddExpenseCommand { get; set; }
	
	readonly CategoriesRepository _categoriesRepository;
	readonly ExpensesRepository _expensesRepository;
	
	public event Action<ExpenseEntity> ExpenseAdded;


	public AddExpenseWindowViewModel(CategoriesRepository categoriesRepository, ExpensesRepository expensesRepository)
	{
		_categoriesRepository = categoriesRepository;
		_expensesRepository = expensesRepository;
		AddExpenseCommand = new RelayCommand(_ => AddExpense(), CanAddExpense);
		
		Categories = _categoriesRepository.GetAll();
		Category = Categories.FirstOrDefault();
	}

	void AddExpense()
	{
		var expense = new ExpenseEntity
		{
			Name = Name,
			Amount = Amount,
			Date = Date,
			Category = Category
		};
		
		_expensesRepository.Add(expense);
		ExpenseAdded?.Invoke(expense);
	}

	bool CanAddExpense(object obj)
	{
		if (string.IsNullOrWhiteSpace(Name) || Amount < 0 || Date == DateOnly.MinValue)
			return false;
		
		return true;
	}
}