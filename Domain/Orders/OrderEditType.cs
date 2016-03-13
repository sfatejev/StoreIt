using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class OrderEditType
    {
        public int OrderEditTypeId { get; set; }

        [MaxLength(32)]
        public String OrderEditTypeValue { get; set; } 
        public String OrderEditTypeDescription { get; set; }
        public bool OrderEditTypeActive { get; set; }

        public virtual List<OrderEdit> OrderEdits { get; set; }
    }
}
