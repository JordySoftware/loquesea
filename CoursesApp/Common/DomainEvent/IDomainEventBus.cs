namespace Common.DomainEvent
{
    public interface IDomainEventBus
    {
        Task Execute<T>(T domainEvent) where T : IDomainEvent;
    }
}
