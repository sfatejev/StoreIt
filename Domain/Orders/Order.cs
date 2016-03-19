using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.People;

namespace Domain.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderPaymentDate { get; set; }

        public int OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }

        public int ClientId { get; set; }
        public virtual Person Client { get; set; }

        public int EmployeeId { get; set; }
        public virtual Person Employee { get; set; }

        public virtual List<OrderEdit> OrderEdits { get; set; }
        public virtual List<OrderedProduct> OrderedProducts { get; set; }
    }
}
