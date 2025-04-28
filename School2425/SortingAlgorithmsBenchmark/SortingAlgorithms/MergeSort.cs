namespace SortingAlgorithmsBenchmark.SortingAlgorithms;

public class MergeSort : ISortingAlgorithm
{
    public void Sort(IList<int> list)
    {
        if (list.Count == 1)
            return;

        var leftList = list.Take(list.Count / 2).ToList();
        var rightList = list.Skip(list.Count / 2).ToList();

        Sort(leftList);
        Sort(rightList);

        Merge(leftList, rightList, list);
    }
    
    private void Merge(IList<int> leftList, IList<int> rightList, IList<int> list)
    {
        var i = 0;
        var l = 0;
        var r = 0;

        while (l < leftList.Count && r < rightList.Count)
        {
            list[i++] = leftList[l] < rightList[r] ? leftList[l++] : rightList[r++];
        }

        while (l < leftList.Count)
        {
            list[i++] = leftList[l++];
        }

        while (r < rightList.Count)
        {
            list[i++] = rightList[r++];
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