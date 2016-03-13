using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders;

namespace Domain.Store
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(32)]
        public String ProductName { get; set; } 
        public float ProductValue { get; set; } //TODO 2 digits after comma, 8 digits max
        public bool ProductActive { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual List<ProductEdit> ProductEdits { get; set; }
        public virtual List<OrderedProduct> OrderedProducts { get; set; }
        public virtual List<StoredProduct> StoredProducts { get; set; }

    }
}
