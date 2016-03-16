using DAL.Interfaces;
using DAL.Interfaces.Users;
using Domain.Users;

namespace DAL.Repositories.Users
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}