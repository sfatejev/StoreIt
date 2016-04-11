
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNet.Identity;

namespace DAL.Interfaces.Users
{

    public interface IRoleRepository : IRoleRepository<int, Role>
    {
    }

    public interface IRoleRepository<in TKey, TRole> : IEFRepository<TRole>
        where TRole : class, IRole<TKey>
    {
        TRole GetByRoleName(string roleName);
        List<TRole> GetRolesForUser(TKey userId);
    }
}