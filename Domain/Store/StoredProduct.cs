using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class StoredProduct
    {
        public int StoredProductId { get; set; }
        public int Quantity { get; set; }

        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
