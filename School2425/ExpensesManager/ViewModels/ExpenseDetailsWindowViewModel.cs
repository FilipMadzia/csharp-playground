using System;
using System.Windows.Input;
using ExpensesManager.Commands;
using ExpensesManager.Models;
using ExpensesManager.Repositories;

namespace ExpensesManager.ViewModels;

public class ExpenseDetailsWindowViewModel
{
	public ExpenseEntity SelectedExpense { get; set; }
	public ICommand DeleteExpenseCommand { get; set; }
	
	public event Action<ExpenseEntity> ExpenseDeleted;
	public Action CloseAction { get; set; }
	
	readonly ExpensesRepository _expensesRepository;

	public ExpenseDetailsWindowViewModel(ExpenseEntity expense, ExpensesRepository expensesRepository)
	{
		_expensesRepository = expensesRepository;
		SelectedExpense = expense;

		DeleteExpenseCommand = new RelayCommand(DeleteExpense, _ => true);
	}
	
	void DeleteExpense(object obj)
	{
		_expensesRepository.Delete(SelectedExpense);
		CloseAction?.Invoke();
		ExpenseDeleted?.Invoke(SelectedExpense);
	}
}