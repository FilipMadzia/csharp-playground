using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace csv_file_exercise;

class Program
{
	static void Main()
	{
		HotelsExercise();
	}

	static void HotelsExercise()
	{
		var config = new CsvConfiguration(CultureInfo.InvariantCulture)
		{
			Delimiter = ";"
		};

		using var reader = new StreamReader("hotele.csv");
		using var csv = new CsvReader(reader, config);

		var hotels = csv.GetRecords<Hotel>().ToList();

        // zad 1
        Console.WriteLine("===Zad 1===");
        var zad1 = hotels.Where(x => x.Address.Contains("Bielsko-Bia"));
		foreach(var hotel in zad1)
		{
			Console.WriteLine($"{hotel.Name} - {hotel.Address}");
		}

		// zad 2
        Console.WriteLine("===Zad 2===");
		var zad2 = hotels.Where(x => x.FacilityCategory.Contains("****")).Count();
        Console.WriteLine(zad2);

        // zad 3
        Console.WriteLine("===Zad 3===");
		var zad3 = hotels.DistinctBy(x => x.FacilityCategory);
		foreach(var hotel in zad3)
		{
            Console.WriteLine(hotel.FacilityCategory);
        }

        // zad 4
        Console.WriteLine("===Zad 4===");
		var zad4 = hotels.DistinctBy(x => x.ServiceType);
		foreach(var hotel in zad4)
		{
            Console.WriteLine(hotel.ServiceType);
        }
    }

	static void Test()
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