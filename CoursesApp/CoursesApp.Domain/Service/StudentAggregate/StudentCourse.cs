using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Service.StudentAggregate;
public class StudentCourse : IDomainEntity
{
    public StudentCourse() {
        this.StudentsProgress = new List<StudentProgress>();
    }

    public StudentCourse(Guid id, Guid studentId, Guid courseId, string courseTitle, string code, string description)
    {
        this.Id = id;
        this.StudentId = studentId;
        this.CourseId = courseId;
        this.CourseTitle = courseTitle;
        this.Code = code;
        this.Description = description;
        this.StudentsProgress = new List<StudentProgress>();
    }

    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; } // Mismo id de curso sin relacionarse en este contexto
    public string Code { get; private set; }
    public string CourseTitle { get; private set; } // El titulo del curso hereda del contexto de curso
    public string Description { get; private set; }
    public virtual Student Student { get; private set; }
    public List<StudentProgress> StudentsProgress { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new StudentCourseValidation().Validate(this);
    }

}