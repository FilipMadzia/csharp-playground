using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace PomodoroTimer;

public partial class MainWindow : Window
{
	private bool _isTimerRunning;
	private readonly int _initialSeconds = 25 * 60; // 25min = 25 * 60s
	private int _timerSeconds;
	private DispatcherTimer _dispatcherTimer;
	
	public MainWindow()
	{
		InitializeComponent();
		
		_dispatcherTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromSeconds(1)
		};
		
		_dispatcherTimer.Tick += OnDispatcherTimerTick; 
	}

	private void OnDispatcherTimerTick(object? sender, EventArgs e)
	{
		if (_timerSeconds > 0)
		{
			_timerSeconds--;
			UpdateTimerDisplay(_timerSeconds);
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

	
	private void UpdateTimerDisplay(int totalSeconds)
	{
		var minutes = totalSeconds / 60;
		var seconds = totalSeconds % 60;
		
		TimerLbl.Content = $"{minutes:D2}:{seconds:D2}";
	}
}