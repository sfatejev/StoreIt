﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNet.Identity;

namespace Domain.Users
{
    /// <summary>
    ///     Represents a Role entity, PK - int
    /// </summary>
    public class Role : Role<int, Role, User, UserClaim, UserLogin, UserRole>
    {
        public Role()
        {
        }

        public Role(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class Role<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole> : IRole<TKey>
        where TRole : Role<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUser : User<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserClaim : UserClaim<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserLogin : UserLogin<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserRole : UserRole<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
    {
        public Role()
        {
            Users = new List<TUserRole>();
        }

        public TKey Id { get; set; }

        [DisplayName("Role name")]
        public string Name { get; set; }

        public virtual ICollection<TUserRole> Users { get; set; }
    }
}