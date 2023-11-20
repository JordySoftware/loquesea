using Common.Model;
using CoursesApp.Domain.Sales.CourseAggregate;

namespace CoursesApp.Infrastructure.Sales.CourseInfrastructure;

public class CourseRepository : Repository<Domain.Sales.CourseAggregate.Course>, ICourseRepository
{

    public CourseRepository(IDbContext context)
        :base(context)
    {}

    public List<Domain.Sales.CourseAggregate.Course> GetByStatus(CourseStatus status)
    {
        return this._dbSet.Where(r => r.Status == status).ToList();
    }
}
