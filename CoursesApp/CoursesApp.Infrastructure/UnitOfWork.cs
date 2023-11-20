using Common.DomainEvent;
using Common.Model;
using CoursesApp.Domain;
using CoursesApp.Domain.Sales.BuyerAggregate;
using CoursesApp.Domain.Sales.CourseAggregate;
using CoursesApp.Domain.Security.RoleAggregate;
using CoursesApp.Domain.Service.StudentAggregate;
using System.Data.Entity;

namespace CoursesApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private IDomainEventBus _domainEventBus { get; set; }
        private DbContextTransaction _transaction;
        private bool _disposed = false;

        public IRoleRepository _roleRepository { get; private set; }

        public ICourseRepository _courseRepository { get; private set; }

        public IBuyerRepository _buyerRepository { get; private set; }

        public IStudentRepository _studentRepository { get; private set; }

        public UnitOfWork(IDbContext context, IDomainEventBus domainEventBus, IRoleRepository roleRepository, ICourseRepository courseRepository,
            IBuyerRepository buyerRepository, IStudentRepository studentRepository)
        {
            _context = context;
            _domainEventBus = domainEventBus;

            _roleRepository = roleRepository;
            _courseRepository = courseRepository;
            _buyerRepository = buyerRepository;
            _studentRepository = studentRepository;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit(AggregateRoot aggregateRoot)
        {
            if (_disposed) { throw new ObjectDisposedException(GetType().FullName); }

            _context.SaveChanges();

            var _uncommittedDomainEvents = aggregateRoot.GetUncommittedDomainEvents();
            foreach (var domainEvent in _uncommittedDomainEvents)
            {
                var _domainEvent = (dynamic)Convert.ChangeType(domainEvent, domainEvent.GetType());
                _domainEventBus.Execute(_domainEvent);
            }
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _context != null)
            {
                _context.Dispose();
            }

            if (disposing && _transaction != null)
            {
                _transaction.Dispose();
            }

            _disposed = true;
        }
    }
}
