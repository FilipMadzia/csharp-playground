using CsvHelper.Configuration.Attributes;

namespace csv_file_exercise;

public class Hotel
{
	[Index(0)]
	public int Id { get; set; }
	[Index(1)]
	public string Name { get; set; }
	[Index(2)]
	public string PhoneNubmer { get; set; }
	[Index(3)]
	public string Email { get; set; }
	[Index(4)]
	public string ServiceType { get; set; }
	[Index(5)]
	public string FacilityCategory { get; set; }
	[Index(6)]
	public string FacilityType { get; set; }
	[Index(7)]
	public string Address { get; set; }
}
