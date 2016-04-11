using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders;
using Domain.People;
using Domain.Store;
using Domain.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Users
{
    public class User : User<int, Role, User, UserClaim, UserLogin, UserRole>
    {
        //delete? public int UserId { get; set; }
        //delete? public String Username { get; set; } //TODO! 16 digits max
        //delete? public String Password { get; set; } //TODO! 40 digits (hash length)
        //delete? public bool UserActive { get; set; }

        //delete? public int UserRoleId { get; set; }
        //delete? public virtual UserRole UserRole { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; } //TODO nullable

        public virtual List<ProductEdit> ProductEdits { get; set; }
        public virtual List<OrderEdit> OrderEdits { get; set; }
        //public virtual List<UserEdit> EditsDoneByUser { get; set; } //Edits done by this user
        //public virtual List<UserEdit> EditsMadeToUser { get; set; } //Edits made to this user
        

        public User()
        {
        }

        /// <summary>
        ///     Constructor that takes a userName
        /// </summary>
        /// <param name="userName"></param>
        public User(string userName)
            : this()
        {
            UserName = userName;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager, string authType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authType);
            // Add custom user claims here
            return userIdentity;
        }


    }

    /// <summary>
    ///     IUser implementation, generic
    /// </summary>
    public class User<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole> : IUser<TKey>
        where TRole : Role<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUser : User<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserClaim : UserClaim<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserLogin : UserLogin<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
        where TUserRole : UserRole<TKey, TRole, TUser, TUserClaim, TUserLogin, TUserRole>
    {
        public TKey Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "FirstLastname", ResourceType = typeof(Resources.Domain))]
        public string FirstLastName => FirstName + " " + LastName;

        [Display(Name = "LastFirstname", ResourceType = typeof(Resources.Domain))]
        public string LastFirstName => LastName + " " + FirstName;

        public virtual ICollection<TUserClaim> Claims { get; set; } = new List<TUserClaim>();
        public virtual ICollection<TUserLogin> Logins { get; set; } = new List<TUserLogin>();
        public virtual ICollection<TUserRole> Roles { get; set; } = new List<TUserRole>();
    }
}

