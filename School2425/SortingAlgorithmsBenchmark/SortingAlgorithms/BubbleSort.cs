namespace SortingAlgorithmsBenchmark.SortingAlgorithms;

public class BubbleSort : ISortingAlgorithm
{
    public void Sort(IList<int> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var swapped = false;

            for (var j = 0; j < list.Count - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);

                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    public double Benchmark(IList<int> list)
    {
        var startTime = DateTime.Now;
        
        Sort(list);
        
        var endTime = DateTime.Now;
        
        
        return (endTime - startTime).TotalSeconds;
    }
}