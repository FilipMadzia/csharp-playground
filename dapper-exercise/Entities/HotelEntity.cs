namespace dapper_exercise.Entities;

public class HotelEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double PricePerNight { get; set; }
    public bool HasInternet { get; set; }
    public bool HasTelevision { get; set; }
    public bool HasParking { get; set; }
    public bool HasCafeteria { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool SoftDeleted { get; set; }

    public override string ToString()
    {
        return Name;
    }
}