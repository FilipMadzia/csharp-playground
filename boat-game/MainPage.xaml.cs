namespace boat_game;

public partial class MainPage : ContentPage
{
	private double _rotation = 0;
	private double _windDirection = 0;
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

		GetRandomWindDirection();

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

		if (_rotation < 0)
		{
			_rotation += 360;
		}

		UpdateRotationLabel();

		boatImage.Rotation = _rotation;
	}

	private void OnTurnRight(object sender, EventArgs e)
	{
		_rotation += _rotationSpeed;

		if (_rotation >= 360)
		{
			_rotation -= 360;
		}

		UpdateRotationLabel();

		boatImage.Rotation = _rotation;
	}

	private void OnTimerTick(object sender, EventArgs e)
	{
		double radians = _rotation * Math.PI / 180;
		_x += _speed * Math.Sin(radians);
		_y += _speed * -Math.Cos(radians);

		ClampYPosition();
		ClampXPosition();

		boatImage.TranslationX = _x;
		boatImage.TranslationY = _y;
	}

	private void UpdateRotationLabel()
	{
		rotationLbl.Text = $"{_rotation}°";
	}

	private void ClampYPosition()
	{
		var _maxY = -(Height / 2) + boatImage.Height / 2;
		var _minY = (Height / 2) - boatImage.Height / 2;

		_y = Math.Max(_y, _maxY);
		_y = Math.Min(_y, _minY);
	}

	private void ClampXPosition()
	{
		var _maxX = (Width / 2) - boatImage.Width / 2;
		var _minX = -(Width / 2) + boatImage.Width / 2;

		_x = Math.Min(_x, _maxX);
		_x = Math.Max(_x, _minX);
	}

	private void GetRandomWindDirection()
	{
		_windDirection = new Random().Next(0, 360);

		windDirectionLbl.Text = $"{_windDirection}°";
	}
}