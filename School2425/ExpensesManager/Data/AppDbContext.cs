using System;
using System.Collections.Generic;
using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Data;

public class AppDbContext : DbContext
{
	public DbSet<ExpenseEntity> Expenses => Set<ExpenseEntity>();
	public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Database=ExpensesManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
		
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var categoriesSeed = new List<CategoryEntity>
		{
			new() { Id = 1, Name = "Żywność", Description = "", ColorHex = "#D20103" },
			new() { Id = 2, Name = "Rachunki", Description = "", ColorHex = "#FE9900" },
			new() { Id = 3, Name = "Odzież", Description = "", ColorHex = "#060270" },
			new() { Id = 4, Name = "Rozrywka", Description = "", ColorHex = "#98F5F9" }
		};
		
		modelBuilder.Entity<CategoryEntity>().HasData(categoriesSeed);

		var expensesSeed = new List<ExpenseEntity>
		{
			// żywność
			new() { Id = 1, Name = "Jogurty", Amount = 12.99m, Date = new DateOnly(2025, 1, 1), CategoryId = 1 },
			new() { Id = 2, Name = "Mega Rollo Kebab", Amount = 11.50m, Date = new DateOnly(2025, 1, 2), CategoryId = 1 },
			// rachunki
			new() { Id = 3, Name = "Prąd", Amount = 193.12m, Date = new DateOnly(2025, 01, 03), CategoryId = 2 },
			new() { Id = 4, Name = "Abonament za telefon", Amount = 32.99m, Date = new DateOnly(2025, 1, 4), CategoryId = 2 },
			// odzież
			new() { Id = 5, Name = "T-Shirt", Amount = 99.99m, Date = new DateOnly(2025, 1, 5), CategoryId = 3 },
			new() { Id = 6, Name = "Spodnie", Amount = 139.99m, Date = new DateOnly(2025, 1, 6), CategoryId = 3 },
			// rozrywka
			new() { Id = 7, Name = "Kino", Amount = 29.99m, Date = new DateOnly(2025, 1, 7), CategoryId = 4 },
			new() { Id = 8, Name = "Lot helikopterem", Amount = 1299m, Date = new DateOnly(2025, 1, 8), CategoryId = 4 },
		};
		
		modelBuilder.Entity<ExpenseEntity>().HasData(expensesSeed);
		
		base.OnModelCreating(modelBuilder);
	}
}