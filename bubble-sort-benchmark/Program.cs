namespace bubble_sort_benchmark;

class Program
{
	static void WriteList(List<int> list)
	{
		foreach(var listElement in list)
		{
			Console.Write($"{listElement}, ");
		}

		Console.WriteLine();
	}

	static List<int> BubbleSortUnoptimized(List<int> list)
	{
		for(var i = 0; i < list.Count; i++)
		{
			for(var j = 0; j < list.Count - 1; j++)
			{
				if(list[j] > list[j + 1])
				{
					var temp = list[j];
					list[j] = list[j + 1];
					list[j + 1] = temp;
				}
			}
		}

		return list;
	}

	static List<int> BubbleSortOptimized(List<int> list)
	{
		for(int i = 0; i < list.Count; i++)
		{
			bool swapped = false;

			for(int j = 0; j < list.Count - i - 1; j++)
			{
				if(list[j] > list[j + 1])
				{
					int temp = list[j];
					list[j] = list[j + 1];
					list[j + 1] = temp;

					swapped = true;
				}
			}

			if(!swapped) break;
		}

		return list;
	}

	static void Main()
	{
		var random = new Random();

		double unoptimizedTotalTime = 0;
		double optimizedTotalTime = 0;
		int iterations = 10;
		int dataSetSize = 10000;

		for(int i = 0; i < iterations; i++)
		{
			Console.WriteLine($"Iteration: {i}");

			var dataSet = Enumerable.Range(0, dataSetSize).Select(x => random.Next(0, 100)).ToList();

			var startTime = DateTime.Now;

			BubbleSortUnoptimized(dataSet.ToList());

			var endTime = DateTime.Now;

			var timeElapsed = endTime - startTime;
			unoptimizedTotalTime += timeElapsed.TotalSeconds;

			Console.WriteLine($"\tUnoptimized: {timeElapsed.TotalSeconds}s");


			startTime = DateTime.Now;

			BubbleSortOptimized(dataSet.ToList());

			endTime = DateTime.Now;

			timeElapsed = endTime - startTime;
			optimizedTotalTime += timeElapsed.TotalSeconds;

			Console.WriteLine($"\tOptimized: {timeElapsed.TotalSeconds}s");

		}

		Console.WriteLine($"\nResults over {iterations} iterations with list of {dataSetSize} elements");
		Console.WriteLine($"\tAverage Unoptimized bubble sort time: {unoptimizedTotalTime / iterations}s");
		Console.WriteLine($"\tAverage Optimized bubble sort time: {optimizedTotalTime / iterations}s");
		Console.WriteLine($"\nWinner: {(optimizedTotalTime < unoptimizedTotalTime ? "optimized" : "unoptimized")}");
	}
}
