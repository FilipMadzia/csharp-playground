using System.Data;
using System.Data.SqlClient;

static class Program
{
	static void Main()
	{
		const string connectionString = "Initial Catalog=HotelixDb; Integrated Security=true";
		const string sqlQuery = "SELECT * FROM dbo.Cities WHERE Name = @Name";

		using var connection = new SqlConnection(connectionString);
		
		var command = new SqlCommand(sqlQuery, connection);
		command.Parameters.AddWithValue("@Name", "Bielsko-Biała");

		try
		{
			connection.Open();

			var reader = command.ExecuteReader();

			while (reader.Read())
			{
				Console.WriteLine($"{reader[0]}, {reader[1]}");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}