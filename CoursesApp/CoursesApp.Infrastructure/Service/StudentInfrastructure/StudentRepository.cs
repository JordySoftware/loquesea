using Common.Model;
using CoursesApp.Domain.Service.StudentAggregate;

namespace CoursesApp.Infrastructure.Service.StudentInfrastructure;

public class StudentRepository : Repository<Student>, IStudentRepository
{

    public StudentRepository(IDbContext context)
        :base(context)
    {}

    public List<Student> GetByStatus(StudentStatus status)
    {
        return this._dbSet.Where(r => r.Status == status).ToList();
    }
}
