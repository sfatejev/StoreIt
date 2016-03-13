using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders;
using Domain.People;
using Domain.Store;
using Domain.Users;

namespace Domain.Users
{
    public class User
    {
        public int UserId { get; set; }
        public String Username { get; set; } //TODO! 16 digits max
        public String Password { get; set; } //TODO! 40 digits (hash length)
        public bool UserActive { get; set; }

        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; } //TODO nullable

        public virtual List<ProductEdit> ProductEdits { get; set; }
        public virtual List<OrderEdit> OrderEdits { get; set; }
        public virtual List<UserEdit>  EditsDoneByUser { get; set; } //Edits done by this user
        public virtual List<UserEdit> EditsMadeToUser { get; set; } //Edits made to this user
    }
}
