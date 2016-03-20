using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Store;

namespace Domain.Orders
{
    public class OrderedProduct
    {
        public int OrderedProductId { get; set; }
        public int OrderedQuantity { get; set; }
        public double OrderedPrice { get; set; } //TODO! real(8,2) - 2 digits after comma, 8 digits maximum.

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
