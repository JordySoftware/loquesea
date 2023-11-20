using Common.Model;
using FluentValidation.Results;

namespace CoursesApp.Domain.Sales.BuyerAggregate
{
    public class Buyer : AggregateRoot, IDomainEntity
    {
        public static Buyer CreateNew(Guid id, string code, string firstName, string lastName, string description)
        {
            Buyer entity = new Buyer
            {
                Id = id,
                Code = code,
                FirstName = firstName,
                LastName = lastName,
                Description = description,
                Status = BuyerStatus.Active,
                CartCourses = new List<CartCourse>(),
                Orders = new List<Order>()
            };

            return entity;
        }

        protected Buyer() {
            this.CartCourses = new List<CartCourse>();
            this.Orders = new List<Order>();
        }

        /*protected Buyer(Guid id, string code, string firstName, string lastName, string description)
        {
            this.Id = id;
            this.Code = code;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Description = description;
            this.Status = BuyerStatus.Active;
            this.CartCourses = new List<CartCourse>();
            this.Orders = new List<Order>();
        }*/

        public Guid Id { get; private set; } // Mismo id de usuario
        public string Code { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Description { get; private set; }
        public BuyerStatus Status { get; private set; }
        public List<CartCourse> CartCourses { get; private set; }
        public List<Order> Orders { get; private set; }

        public ValidationResult ValidateModel()
        {
            return new BuyerValidation().Validate(this);
        }

        public bool ChangeFirstName(string firstName)
        {
            if (FirstName != firstName)
            {
                FirstName = firstName;
                return true;
            }
            return false;
        }

    }
}
