using DAL.Interfaces;
using DAL.Interfaces.Orders;
using Domain.Orders;

namespace DAL.Repositories.Orders
{
    public class OrderedProductRepository : EFRepository<OrderedProduct>, IOrderedProductRepository
    {
        public OrderedProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}