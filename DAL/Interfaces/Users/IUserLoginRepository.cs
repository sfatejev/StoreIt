using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace DAL.Interfaces
{
    public interface IUserLoginRepository : IUserLoginRepository<UserLogin>
    {
    }

    public interface IUserLoginRepository<TUserLogin> : IEFRepository<TUserLogin>
        where TUserLogin : class
    {
        List<TUserLogin> GetAllIncludeUser();
        TUserLogin GetUserLoginByProviderAndProviderKey(string loginProvider, string providerKey);
    }
}