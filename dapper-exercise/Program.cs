using System.Data.SqlClient;
using dapper_exercise.Entities;
using Dapper;

namespace dapper_exercise;

class Program
{
    static void Main()
    {
        using (var connection = new SqlConnection("Database=HotelixDb;Trusted_Connection=true"))
        {
            var hotels = connection.Query<HotelEntity>("SELECT * FROM dbo.Hotels").ToList();
            
            hotels.ForEach(Console.WriteLine);
        }
    }
}