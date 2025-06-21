using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathGraphDrawer;

public partial class MainWindow : Window
{
	private (double x, double y) _origin;
	
	public MainWindow()
	{
		InitializeComponent();

		EquationTextBox.Focus();
	}

	private void EquationTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
	{
		var input = (sender as TextBox)!.Text;
		
		UpdateCanvas();
	}

	private void UpdateCanvas()
	{
		_origin = GetCanvasOrigin();
		
		GraphCanvas.Children.Clear();
		DrawGraphAxes();
		DrawGraphOrigin();
	}

	private void DrawGraphOrigin()
	{
		var graphOriginLabel = new TextBlock
		{
			Text = "0",
			FontSize = 16,
			Foreground = Brushes.Black
		};
		
		Canvas.SetLeft(graphOriginLabel, _origin.x + 10);
		Canvas.SetTop(graphOriginLabel, _origin.y + 10);
		
		GraphCanvas.Children.Add(graphOriginLabel);
	}

	private void DrawGraphAxes()
	{
		var xAxisLine = new Line
		{
			X1 = 0,
			X2 = GraphCanvas.ActualWidth,
			Y1 = _origin.y,
			Y2 = _origin.y,
			Stroke = Brushes.Black
		};
		
		GraphCanvas.Children.Add(xAxisLine);

		var xAxisLabel = new TextBlock
		{
			Text = "x",
			FontSize = 16,
			Foreground = Brushes.Black
		};
		
		Canvas.SetLeft(xAxisLabel, GraphCanvas.ActualWidth - 10);
		Canvas.SetTop(xAxisLabel, _origin.y + 10);

		GraphCanvas.Children.Add(xAxisLabel);

		var yAxisLine = new Line
		{
			X1 = _origin.x,
			X2 = _origin.x,
			Y1 = 0,
			Y2 = GraphCanvas.ActualHeight,
			Stroke = Brushes.Black
		};
		
		GraphCanvas.Children.Add(yAxisLine);
		
		var yAxisLabel = new TextBlock
		{
			Text = "y",
			FontSize = 16,
			Foreground = Brushes.Black
		};
		
		Canvas.SetLeft(yAxisLabel, _origin.x - 20);
		Canvas.SetTop(yAxisLabel, 0);

		GraphCanvas.Children.Add(yAxisLabel);
	}
	
	private (double x, double y) GetCanvasOrigin() => (GraphCanvas.ActualWidth / 2, GraphCanvas.ActualHeight / 2);

	private void GraphCanvas_OnLoaded(object sender, RoutedEventArgs e)
	{
		UpdateCanvas();
	}

	private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
	{
		UpdateCanvas();
	}
}