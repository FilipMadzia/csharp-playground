using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_application;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string equation = string.Empty;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddNumber(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        
        if (button == null)
            throw new ArgumentException("Wrong type");
        
        var content = button.Content;
        
        if ((string)ResultLbl.Content == "0")
            ResultLbl.Content = button.Content.ToString();
        else
            ResultLbl.Content += button.Content.ToString();
    }

    private void ClearButtonClick(object sender, RoutedEventArgs e)
    {
        ResultLbl.Content = "0";
    }
}