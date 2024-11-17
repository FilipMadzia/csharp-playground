using System.Data.SqlClient;
using dapper_contrib_exercise.Entities;
using Dapper.Contrib.Extensions;

namespace dapper_contrib_exercise;

class Program
{
    static void Main()
    {
	    const string connectionString = "Database=HotelixDb; Trusted_Connection=true";

	    using (var connection = new SqlConnection(connectionString))
	    {
		    connection.Open();

		    var hotels = connection.GetAll<HotelEntity>().ToList();
		    
		    hotels.ForEach(Console.WriteLine);
	    }
    }
}