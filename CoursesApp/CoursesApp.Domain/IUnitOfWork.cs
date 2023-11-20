using Common.Model;
using CoursesApp.Domain.Sales.BuyerAggregate;
using CoursesApp.Domain.Sales.CourseAggregate;
using CoursesApp.Domain.Security.RoleAggregate;
using CoursesApp.Domain.Service.StudentAggregate;

namespace CoursesApp.Domain
{
    public interface IUnitOfWork
    {
        IRoleRepository _roleRepository { get; }
        ICourseRepository _courseRepository { get; }
        IBuyerRepository _buyerRepository { get; }
        IStudentRepository _studentRepository { get; }

        void Commit(AggregateRoot aggregateRoot);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
    }
}
