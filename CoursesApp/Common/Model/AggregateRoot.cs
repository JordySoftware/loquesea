using Common.DomainEvent;

namespace Common.Model
{
    public abstract class AggregateRoot: IEventProvider
    {
        private readonly List<IDomainEvent> _domainEvents;

        protected AggregateRoot()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        public IEnumerable<IDomainEvent> GetUncommittedDomainEvents()
        {
            return _domainEvents;
        }

        public void MarkDomainEventsAsCommitted()
        {
            _domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent eve)
        {
            _domainEvents.Add(eve);
        }
    }
}
