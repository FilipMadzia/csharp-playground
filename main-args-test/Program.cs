namespace main_args_test;

class Program
{
	static void Main(string[] args)
	{
		if (args.Length != 1)
			throw new ArgumentException("Wrong number of arguments");
		
		var availableArgs = new List<string> { "-development", "-production" };

		if (!availableArgs.Contains(args[0]))
			throw new ArgumentException("Invalid argument");


		switch (args[0])
		{
			case "-development":
				Development();
				break;
			case "-production":
				Production();
				break;
			default:
				throw new ArgumentException("Invalid argument");
		}
	}
	
	static void Development()
	{
		Console.WriteLine("Launched in development mode");
	}

	static void Production()
	{
		Console.WriteLine("Launched in production mode");
	}
}