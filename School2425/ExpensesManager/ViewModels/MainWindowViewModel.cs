using System;
using System.Collections.ObjectModel;
using ExpensesManager.Models;

namespace ExpensesManager.ViewModels;

public class MainWindowViewModel
{
	public static ObservableCollection<ExpenseEntity> Expenses { get; set; } = [
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
		new() { Id = 1, Name = "Test", Amount = 10.10m, Date = new DateOnly(2025, 1, 1)},
		new() { Id = 2, Name = "Test1", Amount = 20.20m, Date = new DateOnly(2025, 1, 2)},
	];
}