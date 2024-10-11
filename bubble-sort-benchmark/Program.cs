namespace bubble_sort_benchmark;

class Program
{
	static void BubbleSortUnoptimized(List<int> x)
	{
		for(var i = 0; i < x.Count; i++)
		{
			for(var j = 0; j < x.Count - 1; j++)
			{
				if(x[j] > x[j + 1])
				{
					var temp = x[j];
					x[j] = x[j + 1];
					x[j + 1] = temp;
				}
			}
		}
	}

	static void Main()
	{
		var random = new Random();

		var unsortedList = Enumerable.Range(0, 10000).Select(x => random.Next(0, 100));

		var startTime = DateTime.Now;

		BubbleSortUnoptimized(unsortedList.ToList());

		var endTime = DateTime.Now;

		Console.WriteLine($"Unsorted bubble sort time: {(endTime - startTime).TotalSeconds}s");
	}
}
