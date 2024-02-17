using Newtonsoft.Json;

namespace json_file_exercise;

class Program
{
	static void Main()
	{
		var json = File.ReadAllText("users_data.json");

		var records = JsonConvert.DeserializeObject<List<User>>(json) ?? throw new Exception();

		foreach(var record in records)
		{
			Console.WriteLine(record.FirstName);
		}
	}
}