using Common.Model;
using CoursesApp.Domain.Security.RoleAggregate;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CoursesApp.Infrastructure.Security.RoleInfrastructure
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDbContext context) : base(context)
        {}

        public void AddUser(User user)
        {
            DbEntityEntry entry = _context.Entry(user);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _context.Set<User>().Add(user);
            }
        }

        public List<Role> GetByStatus(RoleStatus status)
        {
            return _dbSet.Where(r => r.Status == status).ToList();
        }

        public Role GetByUserCode(string userCode)
        {
            return _dbSet.Where(r => r.Users.Any(u => u.Code == userCode)).Include(r => r.Users).SingleOrDefault();
        }

        public Role GetByUserId(Guid userId)
        {
            return _dbSet.Where(r => r.Users.Any(u => u.Id == userId)).Include(r => r.Users).SingleOrDefault();
        }
    }
}
