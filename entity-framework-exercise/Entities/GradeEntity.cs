namespace entity_framework_exercise.Entities;

public class GradeEntity
{
    public int Id { get; set; }
    public string GradeName { get; set; } = string.Empty;

    public List<StudentEntity> Students { get; set; } = [];
}