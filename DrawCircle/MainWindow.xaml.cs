using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawCircle;

public partial class MainWindow : Window
{
	private readonly (double x, double y) _origin;
	
	public MainWindow()
	{
		InitializeComponent();

		_origin = CalculateCanvasOrigin();
		
		// DrawRectangle(100, 100, Brushes.Black);
		
		DrawCircle(10, 100, Brushes.Black);
	}

	void DrawCircle(int stepInDegrees, double radius, Brush brush)
	{
		for (var i = 0; i < 360; i += stepInDegrees)
		{

			var pixel = new Ellipse
			{
				Width = 5,
				Height = 5,
				Fill = brush,
			};
			
			var angleInRadians = i * Math.PI / 180;

			System.Windows.Controls.Canvas.SetLeft(pixel, _origin.x + radius * Math.Cos(angleInRadians));
			System.Windows.Controls.Canvas.SetTop(pixel, _origin.y - radius * Math.Sin(angleInRadians));
			
			Canvas.Children.Add(pixel);
		}
	}

	void DrawRectangle(double height, double width, Brush brush)
	{
		var topLine = new Line
		{
			X1 = _origin.x - width / 2,
			Y1 = _origin.y - height / 2,
			X2 = _origin.x + width / 2,
			Y2 = _origin.y - height / 2,
			Stroke = brush
		};
		
		var bottomLine = new Line
		{
			X1 = _origin.x - width / 2,
			Y1 = _origin.y + height / 2,
			X2 = _origin.x + width / 2,
			Y2 = _origin.y + height / 2,
			Stroke = brush
		};

		var leftLine = new Line
		{
			X1 = _origin.x - width / 2,
			Y1 = _origin.y - height / 2,
			X2 = _origin.x - width / 2,
			Y2 = _origin.y + height / 2,
			Stroke = brush
		};
		
		var rightLine = new Line
		{
			X1 = _origin.x + width / 2,
			Y1 = _origin.y - height / 2,
			X2 = _origin.x + width / 2,
			Y2 = _origin.y + height / 2,
			Stroke = brush
		};
		
		Canvas.Children.Add(topLine);
		Canvas.Children.Add(bottomLine);
		Canvas.Children.Add(leftLine);
		Canvas.Children.Add(rightLine);
	}

	(double x, double y) CalculateCanvasOrigin()
	{
		return (Canvas.Width / 2, Canvas.Height / 2);
	}
}