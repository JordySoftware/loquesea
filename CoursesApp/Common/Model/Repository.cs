using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace Common.Model
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected DbSet<T> _dbSet { get; set; }
        protected IDbContext _context { get; set; }

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = _context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match).SingleOrDefault();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _dbSet.Where(match);
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        private void Delete(T entity)
        {
            DbEntityEntry entry = _context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }
    }
}
