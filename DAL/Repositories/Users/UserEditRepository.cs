using DAL.Interfaces;
using DAL.Interfaces.Users;
using Domain.Users;

namespace DAL.Repositories.Users
{
    public class UserEditRepository : EFRepository<UserEdit>, IUserEditRepository
    {
        public UserEditRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}