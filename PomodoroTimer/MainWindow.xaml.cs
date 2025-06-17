using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace PomodoroTimer;

public partial class MainWindow : Window
{
	private bool _isTimerRunning = false;
	private readonly int _initialSeconds = 25 * 60; // 25min = 25 * 60s
	private int _timerSeconds = 25 * 60;
	private DispatcherTimer _dispatcherTimer;
	
	public MainWindow()
	{
		InitializeComponent();
		
		_dispatcherTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromSeconds(1)
		};
		
		_dispatcherTimer.Tick += DispatcherTimerTick; 
	}

	private void DispatcherTimerTick(object? sender, EventArgs e)
	{
		if (_timerSeconds > 0)
		{
			_timerSeconds--;
			UpdateTimerDisplay();
		}
		else
		{
			_dispatcherTimer.Stop();
			_isTimerRunning = false;
			StartBtn.Content = "Start";
			StartBtn.Foreground = new SolidColorBrush(Colors.Green);
		}
	}

	private void StartBtn_OnClick(object sender, RoutedEventArgs e)
	{
		if (_isTimerRunning)
		{
			_dispatcherTimer.Stop();
			StartBtn.Content = "Start";
			StartBtn.Foreground = new SolidColorBrush(Colors.Green);
		}
		else
		{
			if (_timerSeconds <= 0)
				_timerSeconds = _initialSeconds;

			_dispatcherTimer.Start();
			StartBtn.Content = "Stop";
			StartBtn.Foreground = new SolidColorBrush(Colors.Red);
		}
    
		_isTimerRunning = !_isTimerRunning;
	}

	
	private void UpdateTimerDisplay()
	{
		int minutes = _timerSeconds / 60;
		int seconds = _timerSeconds % 60;
		TimerLbl.Content = $"{minutes:D2}:{seconds:D2}";
	}
}