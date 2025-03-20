namespace cars_intersection;

public class Intersection(int iterations)
{
    private readonly Queue<Car> _n = [];
    private readonly Queue<Car> _e = [];
    private readonly Queue<Car> _s = [];
    private readonly Queue<Car> _w = [];

    private bool _nsLights;

    public void Run()
    {
        Console.WriteLine("===Program started===");
        
        for (var i = 0; i < iterations; i++)
        {
            Console.WriteLine($"===Iteration {i}===");
            
            var random = new Random();

            switch (random.Next(4))
            {
                case 0:
                    _n.Enqueue(new Car(Direction.N));
                    Console.WriteLine($"Car coming from {_n.Last().FromDirection}, wants to drive to {_n.Last().ToDirection}");
                    break;
                case 1:
                    _e.Enqueue(new Car(Direction.E));
                    Console.WriteLine($"Car coming from {_e.Last().FromDirection}, wants to drive to {_e.Last().ToDirection}");
                    break;
                case 2:
                    _s.Enqueue(new Car(Direction.S));
                    Console.WriteLine($"Car coming from {_s.Last().FromDirection}, wants to drive to {_s.Last().ToDirection}");
                    break;
                case 3:
                    _w.Enqueue(new Car(Direction.W));
                    Console.WriteLine($"Car coming from {_w.Last().FromDirection}, wants to drive to {_w.Last().ToDirection}");
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
            
            SetRandomLights();

            Console.WriteLine(_nsLights ? "Green lights at NS" : "Green lights at WE");

            if (_nsLights)
            {
                if (_n.Count > 0 && _n.Peek().ToDirection == Direction.S)
                    Console.WriteLine($"Car coming from N drives to {_n.Dequeue().ToDirection}");
                
                else if (_s.Count > 0 && _s.Peek().ToDirection == Direction.N)
                    Console.WriteLine($"Car coming from S drives to {_s.Dequeue().ToDirection}");
                
                else if (_n.Count > 0 && (_n.Peek().ToDirection == Direction.E || _n.Peek().ToDirection == Direction.W))
                    Console.WriteLine($"Car coming from N drives to {_n.Dequeue().ToDirection}");
                
                else if (_s.Count > 0 && (_s.Peek().ToDirection == Direction.E || _s.Peek().ToDirection == Direction.W))
                    Console.WriteLine($"Car coming from S drives to {_s.Dequeue().ToDirection}");
            }
            else
            {
                if (_w.Count > 0 && _w.Peek().ToDirection == Direction.E)
                    Console.WriteLine($"Car coming from W drives to {_w.Dequeue().ToDirection}");
                
                else if (_e.Count > 0 && _e.Peek().ToDirection == Direction.W)
                    Console.WriteLine($"Car coming from E drives to {_e.Dequeue().ToDirection}");
                    
                else if (_w.Count > 0 && (_w.Peek().ToDirection == Direction.N || _w.Peek().ToDirection == Direction.S))
                    Console.WriteLine($"Car coming from W drives to {_w.Dequeue().ToDirection}");
                    
                else if (_e.Count > 0 && (_e.Peek().ToDirection == Direction.N || _e.Peek().ToDirection == Direction.S))
                    Console.WriteLine($"Car coming from E drives to {_e.Dequeue().ToDirection}");
            }

            Console.WriteLine($"Cars at:\n" +
                              $"N: {_n.Count}\n" +
                              $"E: {_e.Count}\n" +
                              $"S: {_s.Count}\n" +
                              $"W: {_w.Count}\n");
        }

        Console.WriteLine("===Program ended===");
    }

    private void SetRandomLights()
    {
        var random = new Random();
        
        _nsLights = random.Next(2) == 0;
    }
}