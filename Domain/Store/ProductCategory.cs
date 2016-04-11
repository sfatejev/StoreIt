using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }

        [MaxLength(64)]
        public MultiLangString ProductCategoryValue { get; set; } 
        public MultiLangString ProductCategoryDescription { get; set; }
        public bool ProductCategoryActive { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
