using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class Storage
    {
        public int StorageId { get; set; }

        [MaxLength(32)]
        public String StorageName { get; set; }

        public virtual List<StoredProduct> StoredProducts { get; set; }
    }
}
