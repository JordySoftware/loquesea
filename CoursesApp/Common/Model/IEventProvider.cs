using Common.DomainEvent;

namespace Common.Model
{
    internal interface IEventProvider
    {
        IEnumerable<IDomainEvent> GetUncommittedDomainEvents();
        void MarkDomainEventsAsCommitted();
    }
}
