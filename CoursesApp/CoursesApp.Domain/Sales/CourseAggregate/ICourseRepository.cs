using Common.Model;

namespace CoursesApp.Domain.Sales.CourseAggregate;

public interface ICourseRepository : IRepository<Course>
{
    List<Course> GetByStatus(CourseStatus status);
}
