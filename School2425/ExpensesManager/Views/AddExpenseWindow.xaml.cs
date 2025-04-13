using System.Windows;
using ExpensesManager.ViewModels;

namespace ExpensesManager.Views;

public partial class AddExpenseWindow : Window
{
	public AddExpenseWindow(AddExpenseWindowViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}