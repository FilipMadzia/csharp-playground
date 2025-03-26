namespace cars_intersection;

public class Intersection
{
    public Queue<Car> N = [];
    public Queue<Car> E = [];
    public Queue<Car> S = [];
    public Queue<Car> W = [];

    public bool NsLights { get; set; }

    public void RunForIterationsRandom(int iterations)
    {
        Console.WriteLine("===Program started===");
        
        for (var i = 0; i < iterations; i++)
        {
            Console.WriteLine($"===Iteration {i}===");
            
            var random = new Random();

            switch (random.Next(4))
            {
                case 0:
                    N.Enqueue(new Car(Direction.N));
                    Console.WriteLine($"Car coming from {N.Last().FromDirection}, wants to drive to {N.Last().ToDirection}");
                    break;
                case 1:
                    E.Enqueue(new Car(Direction.E));
                    Console.WriteLine($"Car coming from {E.Last().FromDirection}, wants to drive to {E.Last().ToDirection}");
                    break;
                case 2:
                    S.Enqueue(new Car(Direction.S));
                    Console.WriteLine($"Car coming from {S.Last().FromDirection}, wants to drive to {S.Last().ToDirection}");
                    break;
                case 3:
                    W.Enqueue(new Car(Direction.W));
                    Console.WriteLine($"Car coming from {W.Last().FromDirection}, wants to drive to {W.Last().ToDirection}");
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
            
            SetRandomLights();

            Console.WriteLine(NsLights ? "Green lights at NS" : "Green lights at WE");

            if (NsLights)
            {
                if (N.Count > 0 && N.Peek().ToDirection == Direction.S)
                    Console.WriteLine($"Car coming from N drives to {N.Dequeue().ToDirection}");
                
                else if (S.Count > 0 && S.Peek().ToDirection == Direction.N)
                    Console.WriteLine($"Car coming from S drives to {S.Dequeue().ToDirection}");
                
                else if (N.Count > 0 && (N.Peek().ToDirection == Direction.E || N.Peek().ToDirection == Direction.W))
                    Console.WriteLine($"Car coming from N drives to {N.Dequeue().ToDirection}");
                
                else if (S.Count > 0 && (S.Peek().ToDirection == Direction.E || S.Peek().ToDirection == Direction.W))
                    Console.WriteLine($"Car coming from S drives to {S.Dequeue().ToDirection}");
            }
            else
            {
                if (W.Count > 0 && W.Peek().ToDirection == Direction.E)
                    Console.WriteLine($"Car coming from W drives to {W.Dequeue().ToDirection}");
                
                else if (E.Count > 0 && E.Peek().ToDirection == Direction.W)
                    Console.WriteLine($"Car coming from E drives to {E.Dequeue().ToDirection}");
                    
                else if (W.Count > 0 && (W.Peek().ToDirection == Direction.N || W.Peek().ToDirection == Direction.S))
                    Console.WriteLine($"Car coming from W drives to {W.Dequeue().ToDirection}");
                    
                else if (E.Count > 0 && (E.Peek().ToDirection == Direction.N || E.Peek().ToDirection == Direction.S))
                    Console.WriteLine($"Car coming from E drives to {E.Dequeue().ToDirection}");
            }

            Console.WriteLine($"Cars at:\n" +
                              $"N: {N.Count}\n" +
                              $"E: {E.Count}\n" +
                              $"S: {S.Count}\n" +
                              $"W: {W.Count}\n");
        }

        Console.WriteLine("===Program ended===");
    }
    
    public void RunManualIteration(Car car, bool nsLights)
    {

        switch (car.FromDirection)
        {
            case Direction.N:
                N.Enqueue(car);
                break;
            case Direction.E:
                E.Enqueue(car);
                break;
            case Direction.S:
                S.Enqueue(car);
                break;
            case Direction.W:
                W.Enqueue(car);
                break;
        }
        
        NsLights = nsLights;

        if (NsLights)
        {
            if (N.Count > 0 && N.Peek().ToDirection == Direction.S)
                N.Dequeue();

            else if (S.Count > 0 && S.Peek().ToDirection == Direction.N)
                S.Dequeue();

            else if (N.Count > 0 && (N.Peek().ToDirection == Direction.E || N.Peek().ToDirection == Direction.W))
                N.Dequeue();

            else if (S.Count > 0 && (S.Peek().ToDirection == Direction.E || S.Peek().ToDirection == Direction.W))
                S.Dequeue();
        }
        else
        {
            if (W.Count > 0 && W.Peek().ToDirection == Direction.E)
                W.Dequeue();
            
            else if (E.Count > 0 && E.Peek().ToDirection == Direction.W)
                E.Dequeue();
                
            else if (W.Count > 0 && (W.Peek().ToDirection == Direction.N || W.Peek().ToDirection == Direction.S))
                W.Dequeue();
                
            else if (E.Count > 0 && (E.Peek().ToDirection == Direction.N || E.Peek().ToDirection == Direction.S))
                E.Dequeue();
        }
    }

    private void SetRandomLights()
    {
        var random = new Random();
        
        NsLights = random.Next(2) == 0;
    }

    public void SetNsLights(bool x)
    {
        NsLights = x;
    }
}