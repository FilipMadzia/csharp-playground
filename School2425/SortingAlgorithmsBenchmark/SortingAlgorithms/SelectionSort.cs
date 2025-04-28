namespace SortingAlgorithmsBenchmark.SortingAlgorithms;

public class SelectionSort : ISortingAlgorithm
{
    public void Sort(IList<int> list)
    {
        for (var i = 0; i < list.Count - 1; i++)
        {
            var smallestVal = i;
            
            for (var j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[smallestVal])
                {
                    smallestVal = j;
                }
            }
            
            (list[smallestVal], list[i]) = (list[i], list[smallestVal]);
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