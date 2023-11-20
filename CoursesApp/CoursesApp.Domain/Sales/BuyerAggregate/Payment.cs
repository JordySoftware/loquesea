using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class Payment : IDomainEntity
{
    public Payment() { }
    public Payment(Guid id, Guid orderId, string code, DateTime dateExecution, PaymentMethod method, string description,
                   PaymentStatus status)
    {
        this.Id = id;
        this.OrderId = orderId;
        this.Code = code;
        this.DateExecution = dateExecution;
        this.Method = method;
        this.Description = description;
        this.Status = status;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public string Code { get; private set; }
    public DateTime DateExecution { get; private set; }
    public PaymentMethod Method { get; private set; }
    public string Description { get; private set; }
    public PaymentStatus Status { get; private set; }
    public virtual Order Order { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new PaymentValidation().Validate(this);
    }

}