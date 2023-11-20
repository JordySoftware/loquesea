using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.CourseAggregate;
public class CourseLesson : IDomainEntity
{
    public CourseLesson() {
        this.CourseClasses = new List<CourseClass>();
    }
    public CourseLesson(Guid id, Guid courseId, string code, short orderPosition, string title, string description)
    {
        this.Id = id;
        this.CourseId = courseId;
        this.Code = code;
        this.OrderPosition = orderPosition;
        this.Title = title;
        this.Description = description;
        this.CourseClasses = new List<CourseClass>();
    }

    public Guid Id { get; private set; }
    public Guid CourseId { get; private set; }
    public string Code { get; private set; }
    public short OrderPosition { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public virtual Course Course { get; private set; }
    public List<CourseClass> CourseClasses { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new CourseLessonValidation().Validate(this);
    }

}