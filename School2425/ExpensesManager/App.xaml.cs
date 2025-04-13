using System.Windows;
using ExpensesManager.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public App()
	{
		var services = new ServiceCollection();
	}

	void ConfigureServices(ServiceCollection services)
	{
		services.AddDbContext<AppDbContext>();
	}
}