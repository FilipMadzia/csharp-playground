using System.Windows;
using wpf_introduction.ViewModels;

namespace wpf_introduction.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Main : Window
{
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}