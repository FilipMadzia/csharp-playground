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
			// Parse distances
			int distanceAB = int.Parse(ABEntry.Text);
			int distanceAC = int.Parse(ACEntry.Text);
			int distanceBC = int.Parse(BCEntry.Text);

			// Adjacency matrix for the graph
			int[,] graph = new int[3, 3]
			{
					{ 0, distanceAB, distanceAC },
					{ distanceAB, 0, distanceBC },
					{ distanceAC, distanceBC, 0 }
			};

			// Find shortest path from vertex A (0) to B (1)
			(int[] distances, int[] predecessors) = Dijkstra(graph, 0);

			// Build the path from A to B
			string path = BuildPath(predecessors, 0, 1);

			// Display result
			ResultLabel.Text = $"Shortest path from A to B: {path}. Distance: {distances[1]}";
		}
		catch(Exception ex)
		{
			ResultLabel.Text = $"Error: {ex.Message}";
		}
	}

	private (int[], int[]) Dijkstra(int[,] graph, int source)
	{
		int vertices = graph.GetLength(0);
		int[] dist = new int[vertices]; // Shortest distances
		bool[] sptSet = new bool[vertices]; // Shortest Path Tree Set
		int[] predecessors = new int[vertices]; // To track the path

		// Initialize distances and predecessors
		for(int i = 0; i < vertices; i++)
		{
			dist[i] = int.MaxValue;
			sptSet[i] = false;
			predecessors[i] = -1;
		}
		dist[source] = 0;

		// Find shortest path for all vertices
		for(int count = 0; count < vertices - 1; count++)
		{
			int u = MinDistance(dist, sptSet);
			sptSet[u] = true;

			for(int v = 0; v < vertices; v++)
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
		int min = int.MaxValue, minIndex = -1;

		for(int v = 0; v < dist.Length; v++)
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
		Stack<int> pathStack = new Stack<int>();
		int current = target;

		while(current != -1)
		{
			pathStack.Push(current);
			current = predecessors[current];
		}

		if(pathStack.Peek() != source) // No valid path
		{
			return "No path found";
		}

		// Convert the path from indices to vertex names
		List<string> path = new List<string>();
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