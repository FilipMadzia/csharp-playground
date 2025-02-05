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
	private double _deadAngle = 10;

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
		var radians = _rotation * Math.PI / 180;
		var speed = _speed;

		var relativeAngle = Math.Abs((_rotation - _windDirection + 360) % 360);
		if(relativeAngle > 180)
		{
			relativeAngle = Math.Abs(relativeAngle - 360);
		}

		if(Math.Abs(relativeAngle) <= _deadAngle) speed = 0;
		else if(Math.Abs(relativeAngle) > _deadAngle && Math.Abs(relativeAngle) <= 45) speed = _speed * 0.2;
		else if(Math.Abs(relativeAngle) > 45 && Math.Abs(relativeAngle) <= 90) speed = _speed * 0.5;
		else if(Math.Abs(relativeAngle) > 90 && Math.Abs(relativeAngle) <= 135) speed = _speed * 0.8;
		else if(Math.Abs(relativeAngle) > 135) speed = _speed;
		else speed = 0;

		_x += speed * Math.Sin(radians);
		_y += speed * -Math.Cos(radians);

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
		compassNeedle.Rotation = _windDirection;

		windDirectionLbl.Text = $"{_windDirection}°";
	}
}