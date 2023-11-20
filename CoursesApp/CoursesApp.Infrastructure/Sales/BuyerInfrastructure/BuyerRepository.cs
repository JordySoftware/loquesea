using Common.Model;
using CoursesApp.Domain.Sales.BuyerAggregate;

namespace CoursesApp.Infrastructure.Sales.BuyerInfrastructure;

public class BuyerRepository : Repository<Buyer>, IBuyerRepository
{

    public BuyerRepository(IDbContext context)
        :base(context)
    {}

    public List<Buyer> GetByStatus(BuyerStatus status)
    {
        return this._dbSet.Where(r => r.Status == status).ToList();
    }
}
