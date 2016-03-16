using DAL.Interfaces;
using DAL.Interfaces.Store;
using Domain.Store;

namespace DAL.Repositories.Store
{
    public class ProductEditRepository : EFRepository<ProductEdit>, IProductEditRepository
    {
        public ProductEditRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}