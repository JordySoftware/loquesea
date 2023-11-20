using Common.DomainEvent.Handler;

namespace Common.DomainEvent
{
    public class DomainEventBus : IDomainEventBus
    {
        private readonly IDomainEventHandlerFactory _domainEventHandlerFactory;

        public DomainEventBus(IDomainEventHandlerFactory domainEventHandlerFactory)
        {
            _domainEventHandlerFactory = domainEventHandlerFactory;
        }

        public async Task Execute<T>(T domainEvent) where T : IDomainEvent
        {
            var _handlers = _domainEventHandlerFactory.GetHandlers<T>();

            await Task.Run(() =>
            {
                foreach (var handler in _handlers)
                {
                    handler.Handle(domainEvent);
                }
            });
        }
    }
}
