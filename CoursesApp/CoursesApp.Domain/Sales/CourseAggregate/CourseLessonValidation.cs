using FluentValidation;

namespace CoursesApp.Domain.Sales.CourseAggregate;
public class CourseLessonValidation : AbstractValidator<CourseLesson>
{
    public CourseLessonValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.CourseId)
            .NotNull().WithMessage("CourseId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.OrderPosition)
            .NotNull().WithMessage("OrderPosition cannot be null");

        RuleFor(e => e.Title)
            .NotNull().WithMessage("Title cannot be null")
            .NotEmpty().WithMessage("Title cannot be empty")
            .MaximumLength(100).WithMessage("Title cannot be greater than 100");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

    }
}