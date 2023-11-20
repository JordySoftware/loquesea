using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.CourseAggregate;
public class CourseClass : IDomainEntity
{
    public CourseClass() { }
    public CourseClass(Guid id, Guid courseLessonId, string code, short orderPosition, string title, 
                       MediaType mediaType, string urlMedia, string description)
    {
        this.Id = id;
        this.CourseLessonId = courseLessonId;
        this.Code = code;
        this.OrderPosition = orderPosition;
        this.Title = title;
        this.MediaType = mediaType;
        this.UrlMedia = urlMedia;
        this.Description = description;
    }

    public Guid Id { get; private set; }
    public Guid CourseLessonId { get; private set; }
    public string Code { get; private set; }
    public short OrderPosition { get; private set; }
    public string Title { get; private set; }
    public MediaType MediaType { get; private set; }
    public string UrlMedia { get; private set; }
    public string Description { get; private set; }
    public virtual CourseLesson CourseLesson { get; private set; }

    public ValidationResult ValidateModel()
    {
        return new CourseClassValidation().Validate(this);
    }

}