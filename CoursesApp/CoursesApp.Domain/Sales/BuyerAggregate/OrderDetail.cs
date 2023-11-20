using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class OrderDetail : IDomainEntity
{
    public OrderDetail() { }
    public OrderDetail(Guid id, Guid orderId, Guid courseId, string code, string description)
    {
        this.Id = id;
        this.OrderId = orderId;
        this.CourseId = courseId;
        this.Code = code;
        this.Description = description;
    }

    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid CourseId { get; private set; }
    public string Code { get; private set; }
    public string Description { get; private set; }
    public virtual Order Order { get; private set; }
    public virtual CourseAggregate.Course Course { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new OrderDetailValidation().Validate(this);
    }

}