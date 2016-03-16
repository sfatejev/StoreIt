using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.Orders;
using Domain.Orders;

namespace DAL.Repositories.Orders
{
    public class OrderEditRepository : EFRepository<OrderEdit>, IOrderEditTypeRepository
    {
        public OrderEditRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
