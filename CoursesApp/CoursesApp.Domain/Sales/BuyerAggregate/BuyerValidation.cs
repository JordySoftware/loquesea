using FluentValidation;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class BuyerValidation : AbstractValidator<Buyer>
{
    public BuyerValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.FirstName)
            .NotNull().WithMessage("First name cannot be null")
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be greater than 50");

        RuleFor(e => e.LastName)
            .NotNull().WithMessage("Last name cannot be null")
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be greater than 50");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

        RuleFor(e => e.Status)
            .NotNull().WithMessage("Status cannot be null");

    }
}