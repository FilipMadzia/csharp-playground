using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace list_visualizer;

public partial class MainWindow
{
	List<int> Data { get; set; }

	public MainWindow()
	{
		InitializeComponent();

		Data = FillData();

		DrawList(Data);
	}

	List<int> FillData()
	{
		var random = new Random();

		var data = Enumerable.Range(1, 100).Select(_ => random.Next(1, 101)).ToList();

		return data;
	}

	void DrawList(List<int> list)
	{
		var barWidth = canvas.Width / list.Count;
		var index = 0;

		foreach(var item in list)
		{
			var barHeight = item * (canvas.Height / 100);

			var bar = new Rectangle
			{
				Width = (int)barWidth,
				Height = (int)barHeight,
				Fill = Brushes.Blue
			};

			Canvas.SetLeft(bar, index * barWidth);
			Canvas.SetBottom(bar, 0);


			canvas.Children.Add(bar);

			index++;
		}
	}
}