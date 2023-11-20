using Common.Model;

namespace CoursesApp.Domain.Sales.BuyerAggregate;

public interface IBuyerRepository : IRepository<Buyer>
{
    List<Buyer> GetByStatus(BuyerStatus status);
}
