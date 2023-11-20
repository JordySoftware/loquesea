using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.BuyerAggregate;
public class CartCourse : IDomainEntity
{
    public CartCourse() {

    }

    public CartCourse(Guid id, Guid buyerId, Guid courseId, string code, string description)
    {
        this.Id = id;
        this.BuyerId = buyerId;
        this.CourseId = courseId;
        this.Code = code;
        this.Description = description;
    }

    public Guid Id { get; private set; }
    public Guid BuyerId { get; private set; }
    public Guid CourseId { get; private set; }
    public string Code { get; private set; }
    public string Description { get; private set; }
    public virtual Buyer Buyer { get; private set; }
    public virtual CourseAggregate.Course Course { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new CartCourseValidation().Validate(this);
    }

}