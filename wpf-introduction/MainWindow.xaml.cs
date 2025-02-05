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

namespace wpf_introduction;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var a = double.Parse(this.wspA.Text);
        var b = double.Parse(this.wspB.Text);
        var c = double.Parse(this.wspC.Text);

        var delta = b * b - 4 * a * c;

        if (delta < 0)
        {
            result.Content = "Brak pierwiastków";
        }
        else if (delta == 0)
        {
            var x = (-b + Math.Sqrt(delta)) / (2 * a);
            
            result.Content = "Jeden pierwiastek: " + x;
        }
        else
        {
            var x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            var x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            
            result.Content = "Dwa pierwiastki: " + x1 + ", " + x2;
        }
    }
}