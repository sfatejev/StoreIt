using DAL.Interfaces;
using DAL.Interfaces.Store;
using Domain.Store;

namespace DAL.Repositories.Store
{
    public class ProductCategoryRepository : EFRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}