namespace merge_sort;

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


	static void Main()
	{
		var list = new List<int> { 3, 5, 4, 7, 8, 10, 6, 2, 9 };

		MergeSort(list);

		list.ForEach(Console.WriteLine);
	}
}
