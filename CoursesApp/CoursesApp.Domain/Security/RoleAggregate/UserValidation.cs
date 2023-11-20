using FluentValidation;

namespace CoursesApp.Domain.Security.RoleAggregate;
public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(e => e.Id)
            .NotNull().WithMessage("Id cannot be null");

        RuleFor(e => e.RoleId)
            .NotNull().WithMessage("RoleId cannot be null");

        RuleFor(e => e.Code)
            .NotNull().WithMessage("Code cannot be null")
            .NotEmpty().WithMessage("Code cannot be empty")
            .MaximumLength(20).WithMessage("Code cannot be greater than 20 characters");

        RuleFor(e => e.FirstName)
            .NotNull().WithMessage("First name cannot be null")
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be greater than 50 characters");

        RuleFor(e => e.LastName)
            .NotNull().WithMessage("Last name cannot be null")
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be greater than 50 characters");



        RuleFor(e => e.Address.Street)
            .NotNull().WithMessage("Street cannot be null")
            .NotEmpty().WithMessage("Street cannot be empty")
            .MaximumLength(200).WithMessage("Street cannot be greater than 200 characters");

        RuleFor(e => e.Address.City)
            .NotNull().WithMessage("City cannot be null")
            .NotEmpty().WithMessage("City cannot be empty")
            .MaximumLength(50).WithMessage("City cannot be greater than 50 characters");

        RuleFor(e => e.Address.State)
            .NotNull().WithMessage("State cannot be null")
            .NotEmpty().WithMessage("State cannot be empty")
            .MaximumLength(50).WithMessage("State cannot be greater than 50 characters");

        RuleFor(e => e.Address.Country)
            .NotNull().WithMessage("Country cannot be null")
            .NotEmpty().WithMessage("Country cannot be empty")
            .MaximumLength(50).WithMessage("Country cannot be greater than 50 characters");

        RuleFor(e => e.Address.ZipCode)
            .NotNull().WithMessage("ZipCode cannot be null")
            .NotEmpty().WithMessage("ZipCode cannot be empty")
            .MaximumLength(10).WithMessage("ZipCode cannot be greater than 10 characters");



        RuleFor(e => e.Status)
            .NotNull().WithMessage("Status cannot be null");

        RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .MaximumLength(500).WithMessage("Description cannot be greater than 500 characters");

    }
}