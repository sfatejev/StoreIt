using DAL.Interfaces;
using DAL.Interfaces.Store;

namespace DAL.Repositories.Store
{
    public class ProductRepository : EFRepository<ProductRepository>, IProductRepository
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}