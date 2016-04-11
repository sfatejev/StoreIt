using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.People
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        [MaxLength(64)]
        public MultiLangString ContactTypeValue { get; set; }
        public bool ContactTypeActive { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
