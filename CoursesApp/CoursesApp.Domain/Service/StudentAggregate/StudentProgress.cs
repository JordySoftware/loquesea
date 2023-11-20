using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Service.StudentAggregate;
public class StudentProgress : IDomainEntity
{
    public StudentProgress() { }
    public StudentProgress(Guid id, Guid studentCourseId, Guid courseLessonId, Guid courseClassId, string code, string description)
    {
        this.Id = id;
        this.StudentCourseId = studentCourseId;
        this.CourseLessonId = courseLessonId;
        this.CourseClassId = courseClassId;
        this.Code = code;
        this.Description = description;
    }

    public Guid Id { get; private set; }
    public Guid StudentCourseId { get; private set; }
    public Guid CourseLessonId { get; private set; } // Mismo id de curso lecciones sin relacionarse en este contexto
    public Guid CourseClassId { get; private set; } // Mismo id de curso clases sin relacionarse en este contexto
    public string Code { get; private set; }
    public string Description { get; private set; }
    public virtual StudentCourse StudentCourse { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new StudentProgressValidation().Validate(this);
    }

}