using SortingAlgorithmsBenchmark.SortingAlgorithms;

var random = new Random();

var data = Enumerable.Range(0, 10000)
    .Select(x => random.Next(100))
    .ToList();

var bubbleSort = new BubbleSort();
var bubbleSortData = data.ToList();

Console.WriteLine($"Bubble sort: {bubbleSort.Benchmark(bubbleSortData)}s");

var mergeSort = new MergeSort();
var mergeSortData = data.ToList();

Console.WriteLine($"Merge sort: {mergeSort.Benchmark(mergeSortData)}s");

var quickSort = new QuickSort();
var quickSortData = data.ToList();

Console.WriteLine($"Quick sort: {quickSort.Benchmark(quickSortData)}s");

var selectionSort = new SelectionSort();
var selectionSortData = data.ToList();

Console.WriteLine($"Selection sort: {selectionSort.Benchmark(selectionSortData)}s");