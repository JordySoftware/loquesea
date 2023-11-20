using FluentValidation;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class OrderValidation : AbstractValidator<Order>
{
    public OrderValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.BuyerId)
            .NotNull().WithMessage("BuyerId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.TotalAmount)
            .GreaterThan(0).WithMessage("TotalAmount would be greater than 0");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

    }
}