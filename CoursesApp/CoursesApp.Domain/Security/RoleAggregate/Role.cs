using Common.Model;
using CoursesApp.Domain.Security.RoleAggregate.Events;
using FluentValidation.Results;

namespace CoursesApp.Domain.Security.RoleAggregate
{
    public class Role : AggregateRoot, IDomainEntity
    {
        protected Role()
        {
            Users = new List<User>();
        }

        public static Role CreateNew(string code, string name, string description)
        {
            Role entity = new Role() 
            {
                Id = Guid.NewGuid(),
                Code = code, 
                Name = name,
                Status = RoleStatus.Active,
                Description = description,
                Users = new List<User>()
             };

            return entity;
        }

        public Guid Id { get; private set; }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public RoleStatus Status { get; private set; }

        public string Description { get; private set; }

        public List<User> Users { get; private set; }

        public ValidationResult ValidateModel()
        {
            return new RoleValidation().Validate(this);
        }

        public void AddUser(string code, string firstName, string lastName, Address address, string description)
        {
            Users.Add(User.CreateNew(Id, code, firstName, lastName, address, description));
        }

        public void ChangeUserFirstName(Guid id, string firstName)
        {
            if (Users == null || Users.Count <= 0)
            {
                return;
            }

            User user = Users.Where(u => u.Id == id).SingleOrDefault();
            if (user == null) 
            {
                return;
            }

            bool changed = user.ChangeFirstName(firstName);
            if (changed)
            {
                AddDomainEvent(new UserFirstNameChangedDomainEvent(id, firstName));
            }
        }
    }
}
