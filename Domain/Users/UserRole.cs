using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        [MaxLength(32)]
        public String UserRoleName { get; set; }      
        [MaxLength(256)]
        public String UserRoleDescription { get; set; }

        public bool UserRoleActive { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
