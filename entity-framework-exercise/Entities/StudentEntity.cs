namespace entity_framework_exercise.Entities;

public class StudentEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int GradeId { get; set; }
    public GradeEntity Grade { get; set; }
}