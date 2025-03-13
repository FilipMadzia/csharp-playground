namespace dijkstra_algorithm;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCalculateShortestPathClicked(object sender, EventArgs e)
	{
		try
		{
			var distanceAB = int.Parse(ABEntry.Text);
			var distanceAC = int.Parse(ACEntry.Text);
			var distanceBC = int.Parse(BCEntry.Text);

			if(distanceAB < 0 || distanceAC < 0 || distanceBC < 0)
				throw new Exception("Distance between vertices can't be smaller than 0");

			var graph = new int[3, 3]
			{
				{ 0, distanceAB, distanceAC },
				{ distanceAB, 0, distanceBC },
				{ distanceAC, distanceBC, 0 }
			};

			(int[] distances, int[] predecessors) = Dijkstra(graph, 0);

			var path = BuildPath(predecessors, 0, 1);
			
			ResultLabel.Text = $"Shortest path from A to B:" +
				$"\n{path}" +
				$"\nDistance: {distances[1]}";
		}
		catch
		{
			ResultLabel.Text = "Enter valid numbers";
		}
	}

	private (int[], int[]) Dijkstra(int[,] graph, int source)
	{
		var vertices = graph.GetLength(0);
		var dist = new int[vertices]; // Shortest distances
		var sptSet = new bool[vertices]; // Shortest Path Tree Set
		var predecessors = new int[vertices];

		for(var i = 0; i < vertices; i++)
		{
			dist[i] = int.MaxValue;
			sptSet[i] = false;
			predecessors[i] = -1;
		}

		dist[source] = 0;

		for(var count = 0; count < vertices - 1; count++)
		{
			var u = MinDistance(dist, sptSet);
			sptSet[u] = true;

			for(var v = 0; v < vertices; v++)
			{
				if(!sptSet[v] && graph[u, v] != 0 &&
					dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
				{
					dist[v] = dist[u] + graph[u, v];
					predecessors[v] = u;
				}
			}
		}
		return (dist, predecessors);
	}

	private int MinDistance(int[] dist, bool[] sptSet)
	{
		var min = int.MaxValue;
		var minIndex = -1;

		for(var v = 0; v < dist.Length; v++)
		{
			if(!sptSet[v] && dist[v] <= min)
			{
				min = dist[v];
				minIndex = v;
			}
		}
		return minIndex;
	}

	private string BuildPath(int[] predecessors, int source, int target)
	{
		var pathStack = new Stack<int>();
		var current = target;

		while(current != -1)
		{
			pathStack.Push(current);
			current = predecessors[current];
		}

		if(pathStack.Peek() != source) // No valid path
		{
			return "No path found";
		}

		var path = new List<string>();
		while(pathStack.Count > 0)
		{
			path.Add(IndexToVertex(pathStack.Pop()));
		}

		return string.Join(" -> ", path);
	}

	private string IndexToVertex(int index)
	{
		return index switch
		{
			0 => "A",
			1 => "B",
			2 => "C",
			_ => "Unknown"
		};
	}
}