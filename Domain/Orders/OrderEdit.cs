using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain.Orders
{
    public class OrderEdit
    {
        public int OrderEditId { get; set; }
        public DateTime OrderEditTime { get; set; }

        public int OrderEditTypeId { get; set; }
        public virtual OrderEditType OrderEditType { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
