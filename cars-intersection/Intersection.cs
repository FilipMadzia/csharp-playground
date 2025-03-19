namespace cars_intersection;

public class Intersection(int iterations)
{
    public Queue<Car> N = [];
    public Queue<Car> E = [];
    public Queue<Car> S = [];
    public Queue<Car> W = [];

    private bool NSLights;
    private bool WELights;

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

            Console.WriteLine(NSLights ? "Green lights at NS" : "Green lights at WE");
        }

        Console.WriteLine("===Program ended===");
    }

    private void SetRandomLights()
    {
        var random = new Random();
        
        NSLights = random.Next(2) == 0;
        WELights = !NSLights;
    }
}