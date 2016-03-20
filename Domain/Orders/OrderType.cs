using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class OrderType
    {
        public int OrderTypeId { get; set; }

        [MaxLength(32)]
        public string OrderTypeValue { get; set; } //TODO max 32 digits

        [MaxLength(256)]
        public string OrderTypeDescription { get; set; }
        public bool OrderTypeActive { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
