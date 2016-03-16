using DAL.Interfaces;
using DAL.Interfaces.Store;
using Domain.Store;

namespace DAL.Repositories.Store
{
    public class StoredProductRepository : EFRepository<StoredProduct>, IStoredProductRepository
    {
        public StoredProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}