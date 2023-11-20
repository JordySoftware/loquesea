using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Service.StudentAggregate
{
    public class Student : AggregateRoot, IDomainEntity
    {
        public Student() {
            this.StudentCourses = new List<StudentCourse>();
        }
        public Student(Guid id, string code, string firstName, string lastName, string description)
        {
            this.Id = id;
            this.Code = code;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Description = description;
            this.Status = StudentStatus.Active;
            this.StudentCourses = new List<StudentCourse>();
        }
        public Guid Id { get; private set; } // Mismo id de comprador
        public string Code { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Description { get; private set; }
        public StudentStatus Status { get; private set; }
        public List<StudentCourse> StudentCourses { get; private set; }

        public ValidationResult ValidateModel()
        {
            return new StudentValidation().Validate(this);
        }

        public bool ChangeFirstName(string firstName)
        {
            if (FirstName != firstName)
            {
                FirstName = firstName;
                return true;
            }
            return false;
        }

    }
}
