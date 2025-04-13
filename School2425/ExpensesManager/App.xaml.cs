using System;
using System.Windows;
using ExpensesManager.Data;
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

		serviceCollection.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(
				"Database=ExpensesManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false"));
		
		ConfigureServices(serviceCollection);
		
		_serviceProvider = serviceCollection.BuildServiceProvider();
	}

	void ConfigureServices(ServiceCollection services)
	{
		// ViewModels
		services.AddSingleton<MainWindowViewModel>();
		
		// Views
		services.AddSingleton<MainWindow>();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		
		var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
		mainWindow.Show();
	}
}