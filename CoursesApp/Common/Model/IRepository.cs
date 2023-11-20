using System.Linq.Expressions;

namespace Common.Model
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T GetById(Guid id);
        T Find(Expression<Func<T,bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
