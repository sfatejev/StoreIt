using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class UserEditType
    {
        public int UserEditTypeId { get; set; }

        [MaxLength(32)]
        public String UserEditTypeValue { get; set; }   
        public String UserEditTypeDescription { get; set; }
        public bool UserEditTypeActive { get; set; }

        public virtual List<UserEdit> UserEdits { get; set; }
    }
}
