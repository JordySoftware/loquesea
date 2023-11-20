using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Common.Model
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(Object entity);
        void Dispose();
        Database Database { get; }
    }
}
