namespace merge_sort_vs_bubble_sort;

class Program
{
	static void MergeSort(List<int> list)
	{
		if(list.Count == 1) return;

		var leftList = list.Take(list.Count / 2).ToList();
		var rightList = list.Skip(list.Count / 2).ToList();

		MergeSort(leftList);
		MergeSort(rightList);

		Merge(leftList, rightList, list);
	}

	static void Merge(List<int> leftList, List<int> rightList, List<int> list)
	{
		var i = 0;
		var l = 0;
		var r = 0;

		while(l < leftList.Count && r < rightList.Count)
		{
			list[i++] = leftList[l] < rightList[r] ? leftList[l++] : rightList[r++];
		}

		while(l < leftList.Count)
		{
			list[i++] = leftList[l++];
		}

		while(r < rightList.Count)
		{
			list[i++] = rightList[r++];
		}
	}

	static List<int> BubbleSort(List<int> list)
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
				}
			}

			if(!swapped) break;
		}

		return list;
	}

	static void Main()
	{
		var random = new Random();

		double mergeSortTotalTime = 0;
		double bubbleSortTotalTime = 0;
		int iterations = 10;
		int dataSetSize = 10000;

		for(int i = 0; i < iterations; i++)
		{
			Console.WriteLine($"Iteration: {i}");

			var dataSet = Enumerable.Range(0, dataSetSize).Select(x => random.Next(0, 100)).ToList();

			var startTime = DateTime.Now;

			MergeSort(dataSet.ToList());

			var endTime = DateTime.Now;

			var timeElapsed = endTime - startTime;
			mergeSortTotalTime += timeElapsed.TotalSeconds;

			Console.WriteLine($"\tMerge sort: {timeElapsed.TotalSeconds}s");


			startTime = DateTime.Now;

			BubbleSort(dataSet.ToList());

			endTime = DateTime.Now;

			timeElapsed = endTime - startTime;
			bubbleSortTotalTime += timeElapsed.TotalSeconds;

			Console.WriteLine($"\tBubble sort: {timeElapsed.TotalSeconds}s");

		}

		Console.WriteLine($"\nResults over {iterations} iterations with list of {dataSetSize} elements");
		Console.WriteLine($"\tAverage merge sort time: {mergeSortTotalTime / iterations}s");
		Console.WriteLine($"\tAverage bubble sort time: {bubbleSortTotalTime / iterations}s");
		Console.WriteLine($"\nWinner: {(bubbleSortTotalTime < mergeSortTotalTime ? "bubble sort" : "merge sort")}");
	}
}
