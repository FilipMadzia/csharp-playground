using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawCircle;

public partial class MainWindow : Window
{
	private (double x, double y) _origin;
	
	public MainWindow()
	{
		InitializeComponent();

		_origin = CalculateCanvasOrigin();
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

			Canvas.SetLeft(pixel, _origin.x + radius * Math.Cos(angleInRadians));
			Canvas.SetTop(pixel, _origin.y - radius * Math.Sin(angleInRadians));
			
			Canvas.Children.Add(pixel);
		}
	}

	(double x, double y) CalculateCanvasOrigin()
	{
		return (Canvas.Width / 2, Canvas.Height / 2);
	}

	private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		_origin = CalculateCanvasOrigin();

		if (sender is not Slider slider) return;

		Canvas.Children.Clear();

		var step = 360 - (int)slider.Value;
		DrawCircle(step, 100, Brushes.Black);
		if (InfoLbl != null) InfoLbl.Content = $"Step: {step}°";
	}
}