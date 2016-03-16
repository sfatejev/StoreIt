using DAL.Interfaces;
using DAL.Interfaces.Users;
using Domain.Users;

namespace DAL.Repositories.Users
{
    public class UserEditTypeRepository : EFRepository<UserEditType>, IUserEditTypeRepository
    {
        public UserEditTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}