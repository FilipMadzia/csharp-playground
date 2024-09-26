namespace exploring_attributes;

class Person
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	[Uppercase]
	public string NormalizedLastName { get; set; }
}

class Program
{
	static void Main(string[] args)
	{
		var peter = new Person();
		peter.NormalizedLastName = "peter";

		Console.WriteLine(peter.NormalizedLastName);
	}
}
