namespace main_args_test;

class Program
{
	static void Main(string[] args)
	{
		foreach (var arg in args)
		{
			Console.WriteLine(arg);
		}
	}
}