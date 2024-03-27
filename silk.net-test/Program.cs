using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using System.Drawing;

namespace silk.net_exercise;

public class Program
{
	private static IWindow _window;
	private static GL _gl;

	private static void Main()
	{
		_window = Window.Create(WindowOptions.Default with
		{
			Size = new Vector2D<int>(800),
			Title = "Silk.NET test"
		});

		_window.Render += OnRender;
		_window.Load += OnLoad;

		_window.Initialize();

		var input = _window.CreateInput();
		foreach(var keyboard in input.Keyboards)
		{
			keyboard.KeyDown += OnKeyDown;
		}

		_window.Run();
	}
	private static void OnRender(double deltaTime)
	{
		_gl.ClearColor(Color.CornflowerBlue);
		_gl.Clear(ClearBufferMask.ColorBufferBit);
	}

	private static void OnLoad()
	{
		_gl = _window.CreateOpenGL();
	}

	private static void OnKeyDown(IKeyboard keyboard, Key key, int i)
	{
		if(key.Equals(Key.Space))
		{
            Console.WriteLine("RAAH");
        }
    }
}