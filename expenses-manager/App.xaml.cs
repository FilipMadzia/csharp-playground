using System.Windows;
using expenses_manager.Data;
using Microsoft.Extensions.DependencyInjection;

namespace expenses_manager;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
    }

    void ConfigureServices(ServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }
}