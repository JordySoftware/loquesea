using FluentValidation;

namespace CoursesApp.Domain.Service.StudentAggregate;
public class StudentCourseValidation : AbstractValidator<StudentCourse>
{
    public StudentCourseValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.StudentId)
            .NotNull().WithMessage("StudentId cannot be null");

        RuleFor(e => e.CourseId)
            .NotNull().WithMessage("CourseId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.CourseTitle)
            .NotNull().WithMessage("CourseTitle cannot be null")
            .NotEmpty().WithMessage("CourseTitle cannot be empty")
            .MaximumLength(100).WithMessage("CourseTitle cannot be greater than 100");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

    }
}