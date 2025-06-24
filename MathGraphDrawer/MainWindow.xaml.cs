using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathGraphDrawer;

public partial class MainWindow : Window
{
	private (double x, double y) _origin;
	private string _equation;
	
	public MainWindow()
	{
		InitializeComponent();

		EquationTextBox.Focus();
	}

	private void EquationTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
	{
		_equation = (sender as TextBox)!.Text;
		
		UpdateCanvas();
	}

	private void UpdateCanvas()
	{
		_origin = GetCanvasOrigin();
		
		GraphCanvas.Children.Clear();
		RootsLbl.Content = string.Empty;
		DrawGraphAxes();
		DrawGraphOrigin();
		DrawEquation();
		
	}

	private void DrawEquation()
	{
		if (_equation == null)
			return;
		
		var mathEquationSolver = new MathEquationSolver(_equation);
		
		var roots = mathEquationSolver.GetRoots();
		
		foreach (var root in roots)
		{
			RootsLbl.Content += $"{root}\n";
		}
		
		for (var x1 = -_origin.x; x1 < GraphCanvas.ActualWidth - 1; x1++)
		{
			var y1 = mathEquationSolver.SolveEquationForX(x1);

			var x2 = x1 + 1;
			var y2 = mathEquationSolver.SolveEquationForX(x2);
			
			/*if (GraphCanvas.ActualHeight - _origin.y + y1 < 0)
				continue;
			
			if (GraphCanvas.ActualHeight - _origin.y + y2 < 0)
				continue;

			if (_origin.y - y1 < 0)
				continue;
			
			if (_origin.y - y2 < 0)
				continue;*/

			var line = new Line
			{
				X1 = _origin.x + x1,
				X2 = _origin.x + x2,
				Y1 = _origin.y - y1,
				Y2 = _origin.y - y2,
				Stroke = Brushes.Red
			};

			GraphCanvas.Children.Add(line);
		}
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