using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

public class MainWindowViewModel
{
	public ObservableCollection<ExpenseEntity> Expenses { get; set; }
	public List<ISeries> Series { get; set; }
	public ICommand ShowAddExpenseWindowCommand { get; set; }

	readonly ExpensesRepository _expensesRepository;
	readonly CategoriesRepository _categoriesRepository;

	public MainWindowViewModel(ExpensesRepository expensesRepository, CategoriesRepository categoriesRepository, AddExpenseWindowViewModel addExpenseWindowViewModel)
	{
		_expensesRepository = expensesRepository;
		_categoriesRepository = categoriesRepository;
		
		ShowAddExpenseWindowCommand = new RelayCommand((object _) => new AddExpenseWindow(addExpenseWindowViewModel).Show(), (object _) => true);
		
		var expenses = _expensesRepository.GetAllIncluding();
		
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);
		Series = GetSeries();
	}

	List<ISeries> GetSeries()
	{
		var categoryFrequency = _expensesRepository
			.GetAll()
			.GroupBy(x => x.Category.Name)
			.Select(group => new
			{
				CategoryName = group.Key,
				Count = group.Count()
			}).ToList();
		
		return categoryFrequency
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
			}).ToList();
	}

	Paint GetCategoryFill(string categoryName)
	{
		var category = _categoriesRepository.GetByName(categoryName);
		
		if (category == null)
			throw new Exception($"Category {categoryName} not found");

		return new SolidColorPaint(SKColor.Parse(category.ColorHex));
	}
}