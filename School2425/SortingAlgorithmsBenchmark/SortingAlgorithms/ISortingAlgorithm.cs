namespace SortingAlgorithmsBenchmark.SortingAlgorithms;

public interface ISortingAlgorithm
{
    public void Sort(IList<int> list);
    public double Benchmark(IList<int> list);
}