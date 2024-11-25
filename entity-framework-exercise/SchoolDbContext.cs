using entity_framework_exercise.Entities;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_exercise;

public class SchoolDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<GradeEntity> Grades { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Database=SchoolDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
    }
}