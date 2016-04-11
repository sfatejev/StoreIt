using System.Collections.Generic;
using Domain.Users;

namespace DAL.Interfaces.Users
{
    public interface IUserClaimRepository : IUserClaimRepository<UserClaim>
    {
    }

    public interface IUserClaimRepository<TUserClaim> : IEFRepository<TUserClaim>
        where TUserClaim : class
    {
        List<TUserClaim> AllIncludeUser();
    }
}