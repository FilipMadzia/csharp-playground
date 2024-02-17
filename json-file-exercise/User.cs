using Newtonsoft.Json;

namespace json_file_exercise;

public class User
{
	[JsonProperty("id")]
	public int Id { get; set; }
	[JsonProperty("first_name")]
	public string FirstName { get; set; }
	[JsonProperty("last_name")]
	public string LastName { get; set; }
	[JsonProperty("email")]
	public string Email { get; set; }
	[JsonProperty("gender")]
	public string Gender { get; set; }
	[JsonProperty("ip_address")]
	public string IPAddress { get; set; }
}
