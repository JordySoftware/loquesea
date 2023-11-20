using Common.Model;

namespace CoursesApp.Domain.Service.StudentAggregate;

public interface IStudentRepository : IRepository<Student>
{
    List<Student> GetByStatus(StudentStatus status);
}
