using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Point = System.Drawing.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace DefendTheBase;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private (double x, double y) _canvasCenter;
	private readonly DebugWindow _debugWindow;
	private DispatcherTimer _timer;
	
	public MainWindow()
	{
		InitializeComponent();
		
		_debugWindow = new DebugWindow();
		_debugWindow.Show();

		_canvasCenter = GetCanvasCenter(GameCanvas);
		_timer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(100)
		};
		_timer.Tick += UpdateCanvas;
	}

	private void UpdateCanvas(object? sender, EventArgs e)
	{
		_canvasCenter = GetCanvasCenter(GameCanvas);
		GameCanvas.Children.Clear();
		
		DrawBase(GameCanvas, position: _canvasCenter, size: 30);
	}

	private void DrawBase(Canvas canvas, (double x, double y) position, int size)
	{
		var rectangle = new Rectangle
		{
			Width = size,
			Height = size,
			Fill = Brushes.Black
		};
		
		canvas.Children.Add(rectangle);
		Canvas.SetTop(rectangle, position.y - size / 2);
		Canvas.SetLeft(rectangle, position.x - size /2);
	}

	private (double x, double y) GetCanvasCenter(Canvas canvas) => (canvas.ActualWidth / 2, canvas.ActualHeight / 2);

	private void GameCanvas_OnMouseMove(object sender, MouseEventArgs e)
	{
		_debugWindow.MousePosition = e.GetPosition(this);
	}

	private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
	{
		UpdateCanvas(this, EventArgs.Empty);
	}
}