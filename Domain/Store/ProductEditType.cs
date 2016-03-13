using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class ProductEditType
    {
        public int ProductEditTypeId { get; set; }

        [MaxLength(64)]
        public String ProductEditTypeValue { get; set; }    
        public bool ProductEditTypeActive { get; set; }

        public virtual List<ProductEdit> ProductEdits { get; set; }
    }
}
