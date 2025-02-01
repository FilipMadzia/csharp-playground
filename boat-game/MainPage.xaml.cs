namespace boat_game;

public partial class MainPage : ContentPage
{
	private double _rotation = 0;
	private double _speed = 3;
	private double _rotationSpeed = 3;
	private double _x = 0;
	private double _y = 0;
	private double _refreshRate = 30;

	private IDispatcherTimer _timer;
	private IDispatcherTimer _turnTimer;

	public MainPage()
	{
		InitializeComponent();

		_timer = Dispatcher.CreateTimer();
		_timer.Interval = TimeSpan.FromMilliseconds(_refreshRate);
		_timer.Tick += OnTimerTick;
		_timer.Start();

		_turnTimer = Dispatcher.CreateTimer();
		_turnTimer.Interval = TimeSpan.FromMilliseconds(_refreshRate);
	}

	private void OnTurnLeftButtonPressed(object sender, EventArgs e)
	{
		_turnTimer.Tick += OnTurnLeft;
		_turnTimer.Start();
	}

	private void OnTurnLeftButtonReleased(object sender, EventArgs e)
	{
		_turnTimer.Tick -= OnTurnLeft;
		_turnTimer.Stop();
	}

	private void OnTurnRightButtonPressed(object sender, EventArgs e)
	{
		_turnTimer.Tick += OnTurnRight;
		_turnTimer.Start();
	}

	private void OnTurnRightButtonReleased(object sender, EventArgs e)
	{
		_turnTimer.Tick -= OnTurnRight;
		_turnTimer.Stop();
	}

	private void OnTurnLeft(object sender, EventArgs e)
	{
		_rotation -= _rotationSpeed;
		BoatImage.Rotation = _rotation;
	}

	private void OnTurnRight(object sender, EventArgs e)
	{
		_rotation += _rotationSpeed;
		BoatImage.Rotation = _rotation;
	}

	private void OnTimerTick(object sender, EventArgs e)
	{
		double radians = _rotation * Math.PI / 180;
		_x += _speed * Math.Cos(radians);
		_y += _speed * Math.Sin(radians);

		BoatImage.TranslationX = _x;
		BoatImage.TranslationY = _y;
	}
}