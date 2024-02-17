using CsvHelper.Configuration.Attributes;

namespace csv_file_exercise;

public class User
{
	[Index(0)]
	public int Id { get; set; }
	[Index(1)]
	public string FirstName { get; set; }
	[Index(2)]
	public string LastName { get; set; }
	[Index(3)]
	public string Email { get; set; }
	[Index(4)]
	public string Gender { get; set; }
	[Index(5)]
    public string IpAddress { get; set; }
}
