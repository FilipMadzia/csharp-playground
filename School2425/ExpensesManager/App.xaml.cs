using System;
using System.Windows;
using ExpensesManager.Data;
using ExpensesManager.Repositories;
using ExpensesManager.ViewModels;
using ExpensesManager.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	private readonly IServiceProvider _serviceProvider;
	
	public App()
	{
		var serviceCollection = new ServiceCollection();

		serviceCollection.AddDbContext<AppDbContext>();
		
		ConfigureServices(serviceCollection);
		
		_serviceProvider = serviceCollection.BuildServiceProvider();
	}

	void ConfigureServices(ServiceCollection services)
	{
		// ViewModels
		services.AddTransient<MainWindowViewModel>();
		services.AddTransient<AddExpenseWindowViewModel>();
		
		// Views
		services.AddTransient<MainWindow>();
		services.AddTransient<AddExpenseWindow>();
		
		// Repositories
		services.AddTransient<CategoriesRepository>();
		services.AddSingleton<ExpensesRepository>();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		
		var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
		mainWindow.Show();
	}
}