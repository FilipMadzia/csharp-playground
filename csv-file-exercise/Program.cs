using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace csv_file_exercise;

class Program
{
	static void Main()
	{
		var config = new CsvConfiguration(CultureInfo.InvariantCulture);

		using var reader = new StreamReader("users_data.csv");
		using var csv = new CsvReader(reader, config);

		var records = csv.GetRecords<User>().ToList();
		var pokemonCount = 0;

		foreach(var record in records)
		{
			if(record.Gender != "Male" && record.Gender != "Female")
			{
				pokemonCount++;
				Console.WriteLine($"{record.FirstName} {record.LastName} - {record.Gender}");
			}
		}

        Console.WriteLine($"Pokemon count: {pokemonCount}");

		var disctinctPokemons = records.Select(x => x.Gender).Where(x => x != "Male" && x != "Female").Distinct();

		foreach(var pokemon in disctinctPokemons)
		{
			Console.WriteLine(pokemon);
		}
	}
}