using Common.Model;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public interface IRoleRepository: IRepository<Role>
    {
        List<Role> GetByStatus(RoleStatus status);
        void AddUser(User user);
        Role GetByUserId(Guid userId);
        Role GetByUserCode(string userCode);
    }
}
