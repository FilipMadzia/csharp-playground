using System.Windows;
using ExpensesManager.Models;
using ExpensesManager.ViewModels;

namespace ExpensesManager.Views;

public partial class ExpenseDetailsWindow : Window
{
	public ExpenseDetailsWindow(ExpenseDetailsWindowViewModel viewModel)
	{
		InitializeComponent();
		viewModel.CloseAction = () => Close();
		DataContext = viewModel;
	}
}