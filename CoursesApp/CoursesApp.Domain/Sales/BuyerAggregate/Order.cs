using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class Order : IDomainEntity
{
    public Order() {
        this.OrdersDetail = new List<OrderDetail>();
    }

    public Order(Guid id, Guid buyerId, Guid? paymentId, string code, decimal totalAmount, string description)
    {
        this.Id = id;
        this.BuyerId = buyerId;
        this.PaymentId = paymentId;
        this.Code = code;
        this.TotalAmount = totalAmount;
        this.Description = description;
        this.OrdersDetail = new List<OrderDetail>();
    }

    public Guid Id { get; private set; }
    public Guid BuyerId { get; private set; }
    public Guid? PaymentId { get; private set; }
    public string Code { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Description { get; private set; }
    public virtual Buyer Buyer { get; private set; }
    public List<OrderDetail> OrdersDetail { get; private set; }
    public virtual Payment? Payment { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new OrderValidation().Validate(this);
    }

}