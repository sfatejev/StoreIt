using DAL.Interfaces;
using DAL.Interfaces.Users;
using Domain.Users;

namespace DAL.Repositories.Users
{
    public class UserRoleRepository : EFRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}