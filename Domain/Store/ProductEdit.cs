using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain.Store
{
    public class ProductEdit
    {
        public int ProductEditId { get; set; }
        public DateTime ProductEditTime { get; set; }

        public int ProductEditorId { get; set; }
        public virtual User ProductEditor { get; set; }

        public int ProductEditTypeId { get; set; }
        public virtual ProductEditType ProductEditType { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
