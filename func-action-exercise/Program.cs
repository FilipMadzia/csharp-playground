namespace func_action_exercise;

class Program
{
	static void Main()
	{
		Func<int, int, int> funcA;

		funcA = (x, y) =>
		{
			return x * y * y - x;
		};

        Console.WriteLine(funcA(2, 2));

		Action<string, int> actA;

		actA = (x, y) =>
		{
			for(int i = 0; i < y; i++)
			{
                Console.WriteLine(x);
            }
		};
		actA("Hello World", 3);
    }
}
