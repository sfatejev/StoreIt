using DAL.Interfaces;
using DAL.Interfaces.Orders;
using Domain.Orders;

namespace DAL.Repositories.Orders
{
    public class OrderTypeRepository : EFRepository<OrderType>, IOrderEditTypeRepository
    {
        public OrderTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}