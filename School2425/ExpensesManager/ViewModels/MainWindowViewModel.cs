using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using ExpensesManager.Commands;
using ExpensesManager.Models;
using ExpensesManager.Repositories;
using ExpensesManager.Views;
using LiveChartsCore;
using LiveChartsCore.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace ExpensesManager.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
	private ObservableCollection<ExpenseEntity> _expenses;
	public ObservableCollection<ExpenseEntity> Expenses
	{
		get => _expenses;
		set
		{
			_expenses = value;
			OnPropertyChanged(nameof(Expenses));
		}
	}

	private ObservableCollection<ISeries> _series;
	public ObservableCollection<ISeries> Series
	{
		get => _series;
		set
		{
			_series = value;
			OnPropertyChanged(nameof(Series));
		}
	}
	public ICommand ShowAddExpenseWindowCommand { get; set; }
	public ICommand ShowExpenseDetailsWindowCommand { get; set; }

	readonly ExpensesRepository _expensesRepository;
	readonly CategoriesRepository _categoriesRepository;

	public MainWindowViewModel(ExpensesRepository expensesRepository, CategoriesRepository categoriesRepository, AddExpenseWindowViewModel addExpenseWindowViewModel)
	{
		_expensesRepository = expensesRepository;
		_categoriesRepository = categoriesRepository;
		
		ShowAddExpenseWindowCommand = new RelayCommand(_ => new AddExpenseWindow(addExpenseWindowViewModel).Show(), _ => true);
		ShowExpenseDetailsWindowCommand = new RelayCommand(ShowExpenseDetails, _ => true);
		
		var expenses = _expensesRepository.GetAllIncluding();
		
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);
		Series = GetSeries();
		
		addExpenseWindowViewModel.ExpenseAdded += OnExpenseAdded;
	}
	
	void ShowExpenseDetails(object obj)
	{
		var expense = obj as ExpenseEntity;
		
		if (expense != null)
		{
			var detailsViewModel = new ExpenseDetailsWindowViewModel(expense, _expensesRepository);
			var detailsWindow = new ExpenseDetailsWindow(detailsViewModel);
			detailsWindow.Show();
			detailsViewModel.ExpenseDeleted += OnExpenseDeleted;
		}
	}

	void OnExpenseDeleted(ExpenseEntity deletedExpense)
	{
		var expenses = _expensesRepository.GetAllIncluding();
		
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);
		Series = GetSeries();
	}
	
	void OnExpenseAdded(ExpenseEntity newExpense)
	{
		var expenses = _expensesRepository.GetAllIncluding();
		
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);
		Series = GetSeries();
	}


	ObservableCollection<ISeries> GetSeries()
	{
		var categoryFrequency = _expensesRepository
			.GetAll()
			.GroupBy(x => x.Category.Name)
			.Select(group => new
			{
				CategoryName = group.Key,
				Count = group.Count()
			}).ToList();
		
		return new ObservableCollection<ISeries>(categoryFrequency
			.Select(group => (ISeries)new PieSeries<int>
			{
				Values = [group.Count],
				Name = group.CategoryName,
				DataLabelsPaint = new SolidColorPaint(SKColors.White)
				{
					SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
				},
				DataLabelsFormatter = _ => $"{group.CategoryName} {group.Count}",
				Fill = GetCategoryFill(group.CategoryName)
			}).ToList());
	}

	Paint GetCategoryFill(string categoryName)
	{
		var category = _categoriesRepository.GetByName(categoryName);
		
		if (category == null)
			throw new Exception($"Category {categoryName} not found");

		return new SolidColorPaint(SKColor.Parse(category.ColorHex));
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}