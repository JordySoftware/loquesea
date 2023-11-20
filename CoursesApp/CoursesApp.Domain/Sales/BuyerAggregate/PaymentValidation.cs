using FluentValidation;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class PaymentValidation : AbstractValidator<Payment>
{
    public PaymentValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.OrderId)
            .NotNull().WithMessage("OrderId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20");

        RuleFor(e => e.DateExecution)
            .NotNull().WithMessage("DateExecution cannot be null");

        RuleFor(e => e.Method)
            .NotNull().WithMessage("Method cannot be null");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500");

        RuleFor(e => e.Status)
            .NotNull().WithMessage("Status cannot be null");

    }
}