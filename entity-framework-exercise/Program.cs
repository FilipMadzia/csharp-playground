using entity_framework_exercise;
using entity_framework_exercise.Entities;

using (var context = new SchoolDbContext())
{
    context.Database.EnsureCreated();

    var grade = new GradeEntity { GradeName = "1st grade" };
    var student = new StudentEntity { FirstName = "John", LastName = "Doe", Grade = grade };
    
    context.Students.Add(student);
    
    context.SaveChanges();
    
    var students = context.Students.ToList();
    
    students.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
}