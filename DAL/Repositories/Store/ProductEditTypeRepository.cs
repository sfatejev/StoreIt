using DAL.Interfaces;
using DAL.Interfaces.Store;
using Domain.Store;

namespace DAL.Repositories.Store
{
    public class ProductEditTypeRepository : EFRepository<ProductEditType>, IProductEditTypeRepository
    {
        public ProductEditTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}