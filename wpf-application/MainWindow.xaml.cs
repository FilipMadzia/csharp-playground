using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace wpf_application;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string? _firstEquation;
    private string? _operation;
    private string? _secondEquation;

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
        
        if (_firstEquation == null && _secondEquation == null)
            _firstEquation = content.ToString();
        else if(_firstEquation != null && _secondEquation == null && _operation == null)
            _firstEquation += content.ToString();
        else if(_firstEquation != null && _secondEquation == null && _operation != null)
            _secondEquation = content.ToString();
        else
            _secondEquation += content.ToString();
        
        if ((string)ResultLbl.Content == "0")
            ResultLbl.Content = content.ToString();
        else
            ResultLbl.Content += content.ToString();
    }

    private void ClearButtonClick(object sender, RoutedEventArgs e)
    {
        _operation = null;
        _secondEquation = null;
        ResultLbl.Content = "0";
    }

    private void ParseEquation(object sender, RoutedEventArgs e)
    {
        var num1 = double.Parse(_firstEquation);
        var num2 = double.Parse(_secondEquation);

        var result = 0d;

        switch (_operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                result = num1 / num2;
                break;
        }

        ResultLbl.Content = result.ToString();
        _firstEquation = result.ToString();
        _secondEquation = null;
        _operation = null;
    }

    private void MathAction(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        
        if (button == null)
            throw new ArgumentException("Wrong type");
        
        var content = button.Content;
        
        _operation = content.ToString();
        
        ResultLbl.Content += _operation;
    }
}