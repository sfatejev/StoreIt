using DAL.Interfaces;
using DAL.Interfaces.Store;
using Domain.Store;

namespace DAL.Repositories.Store
{
    public class StorageRepository : EFRepository<Storage>, IStorageRepository
    {
        public StorageRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}