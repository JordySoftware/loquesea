using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.CourseAggregate
{
    public class Course : AggregateRoot, IDomainEntity
    {
        public Course() {
            this.CourseLessons = new List<CourseLesson>();
        }
        public Course(Guid id, string code, string title, decimal unitAmount, string description)
        {
            this.Id = id;
            this.Code = code;
            this.Title = title;
            this.UnitAmount = unitAmount;
            this.Description = description;
            this.Status = CourseStatus.Active;
            this.CourseLessons = new List<CourseLesson>();
        }
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public decimal UnitAmount { get; private set; }
        public string Description { get; private set; }
        public CourseStatus Status { get; private set; }
        public List<CourseLesson> CourseLessons { get; private set; }

        public ValidationResult ValidateModel()
        {
            return new CourseValidation().Validate(this);
        }

    }
}
