using DAL.Interfaces;
using DAL.Interfaces.Orders;
using Domain.Orders;

namespace DAL.Repositories.Orders
{
    public class OrderEditTypeRepository : EFRepository<OrderEditType>, IOrderEditTypeRepository
    {
        public OrderEditTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}