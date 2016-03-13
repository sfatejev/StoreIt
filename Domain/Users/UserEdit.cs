using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class UserEdit
    {
        public int UserEditId { get; set; }
        public DateTime UserEditTime { get; set; }

        public int UserEditorId { get; set; }
        public virtual User UserEditor { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int UserEditTypeId { get; set; }
        public virtual UserEditType UserEditType { get; set; }
    }
}
