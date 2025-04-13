using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ExpensesManager.Data;
using ExpensesManager.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;

namespace ExpensesManager.ViewModels;

public class MainWindowViewModel
{
	public ObservableCollection<ExpenseEntity> Expenses { get; set; }
	public List<ISeries> Series { get; set; }

	private readonly AppDbContext _context;

	public MainWindowViewModel(AppDbContext context)
	{
		_context = context;
		
		var expenses = _context.Expenses.Include(x => x.Category);
		
		Expenses = new ObservableCollection<ExpenseEntity>(expenses);

		var categoryFrequency = _context.Expenses
			.GroupBy(x => x.Category.Name)
			.Select(group => new
			{
				CategoryName = group.Key,
				Count = group.Count()
			}).ToList();
		
		Series = categoryFrequency
			.Select(group => (ISeries)new PieSeries<int>
			{
				Values = [group.Count],
				Name = group.CategoryName,
				DataLabelsPaint = new SolidColorPaint(SKColors.White)
				{
					SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
				},
				DataLabelsFormatter = _ => $"{group.CategoryName} {group.Count}"
			}).ToList();
	}
}