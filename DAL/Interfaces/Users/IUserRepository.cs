using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNet.Identity;

namespace DAL.Interfaces.Users
{

    public interface IUserRepository : IUserRepository<int, User>
    {
    }

    public interface IUserRepository<in TKey, TUser> : IEFRepository<TUser>
        where TUser : class, IUser<TKey>
    {
        TUser GetUserByUserName(string userName);
        TUser GetUserByEmail(string email);
        bool IsInRole(TKey userId, string roleName);
        void AddUserToRole(TKey userId, string roleName);
    }
}