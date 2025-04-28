namespace SortingAlgorithmsBenchmark.SortingAlgorithms;

public class QuickSort : ISortingAlgorithm
{
    public void Sort(IList<int> list)
    {
        if (list.Count <= 1) return;
        QuickSortMethod(list, 0, list.Count - 1);
    }

    private void QuickSortMethod(IList<int> list, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(list, low, high);
            QuickSortMethod(list, low, pivotIndex - 1); // Sort left part
            QuickSortMethod(list, pivotIndex + 1, high); // Sort right part
        }
    }

    private int Partition(IList<int> list, int low, int high)
    {
        int pivot = list[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, high);
        return i + 1;
    }

    private void Swap(IList<int> list, int index1, int index2)
    {
        (list[index1], list[index2]) = (list[index2], list[index1]);
    }

    public double Benchmark(IList<int> list)
    {
        var startTime = DateTime.Now;
        
        Sort(list);
        
        var endTime = DateTime.Now;
        
        
        return (endTime - startTime).TotalSeconds;
    }
}