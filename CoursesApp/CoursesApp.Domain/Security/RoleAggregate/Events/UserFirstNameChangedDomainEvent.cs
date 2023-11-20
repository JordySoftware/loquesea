using Common.DomainEvent;

namespace CoursesApp.Domain.Security.RoleAggregate.Events
{
    public class UserFirstNameChangedDomainEvent: IDomainEvent
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }

        public UserFirstNameChangedDomainEvent(Guid id, string firstName)
        {
            Id = id;
            FirstName = firstName;
        }
    }
}
