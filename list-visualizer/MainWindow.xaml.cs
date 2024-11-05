using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace list_visualizer;

public partial class MainWindow
{
	List<int> Data { get; set; }
	int BarGap { get; set; } = 2;

	public MainWindow()
	{
		InitializeComponent();

		Data = FillData();

		DrawList(Data);
	}
	
	private void RestartButtonOnClick(object sender, RoutedEventArgs e)
	{
		Data = FillData();
		
		DrawList(Data);
	}
	
	private void BubbleSortButtonOnClick(object sender, RoutedEventArgs e)
	{
		BubbleSort(Data);
	}
	
	async void BubbleSort(List<int> list)
	{
		for(int i = 0; i < list.Count; i++)
		{
			bool swapped = false;

			for(int j = 0; j < list.Count - i - 1; j++)
			{
				if(list[j] > list[j + 1])
				{
					(list[j], list[j + 1]) = (list[j + 1], list[j]);

					swapped = true;

					DrawList(list);
					
					await Task.Delay(1);
				}
			}

			if(!swapped) break;
		}
	}

	List<int> FillData()
	{
		var random = new Random();

		var data = Enumerable.Range(1, 100).Select(_ => random.Next(1, 101)).ToList();

		return data;
	}

	void DrawList(List<int> list)
	{
		Canvas.Children.Clear();
		
		var barWidth = (Canvas.Width - BarGap * list.Count) / list.Count;

		for (var i = 0; i < list.Count; i++)
		{
			var barHeight = list[i] * (Canvas.Height / 100);
			
			var bar = new Rectangle
			{
				Width = (int)barWidth,
				Height = (int)barHeight,
				Fill = Brushes.Blue
			};
			
			Canvas.SetLeft(bar, i * (barWidth + BarGap));
			Canvas.SetBottom(bar, 0);

			Canvas.Children.Add(bar);
		}
	}
}