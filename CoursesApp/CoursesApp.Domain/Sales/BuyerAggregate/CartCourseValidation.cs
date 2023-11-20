using FluentValidation;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class CartCourseValidation : AbstractValidator<CartCourse>
{
    public CartCourseValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.BuyerId)
            .NotNull().WithMessage("BuyerId cannot be null");

        RuleFor(e => e.CourseId)
            .NotNull().WithMessage("CourseId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

    }
}