using System.ComponentModel.DataAnnotations.Schema;

namespace movies_api.Data.Entities;

[Table("Movie")]
public class MovieEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string Director { get; set; }
}
