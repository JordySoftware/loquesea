using FluentValidation;

namespace CoursesApp.Domain.Service.StudentAggregate;
public class StudentProgressValidation : AbstractValidator<StudentProgress>
{
    public StudentProgressValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.StudentCourseId)
            .NotNull().WithMessage("StudentCourseId cannot be null");

        RuleFor(e => e.CourseLessonId)
            .NotNull().WithMessage("CourseLessonId cannot be null");

        RuleFor(e => e.CourseClassId)
            .NotNull().WithMessage("CourseClassId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

    }
}