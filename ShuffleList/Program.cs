using Microsoft.Win32;

namespace ShuffleList;

class Program
{
	static void Main()
	{
		var rnd = new Random();

		for(int i = 0; i < 10; i++)
		{
			var nums = new List<int> { 1, 20, 30, 40 };
			var correctIndex = rnd.Next(nums.Count);

			ShuffleList(nums, correctIndex);

            Console.WriteLine($"==={correctIndex}===");
            foreach (var num in nums)
			{
				Console.WriteLine(num);
			}
		}
	}

	static void ShuffleList(List<int> list, int correctIndex)
	{
		var remainingNums = list.ToList();

		list[correctIndex] = remainingNums[0];

		remainingNums.RemoveAt(0);

		for(int i = 0; i < list.Count; i++)
		{
			if(i == correctIndex) continue;

			var rand = new Random();
			var randomIndex = rand.Next(remainingNums.Count);

			list[i] = remainingNums[randomIndex];
			remainingNums.RemoveAt(randomIndex);
		}
	}
}
