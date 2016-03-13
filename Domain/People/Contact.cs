using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.People
{
    public class Contact
    {
        public int ContactId { get; set; }
        public bool ContactActive { get; set; }

        [MaxLength(64)]
        public String ContactValue { get; set; } //TODO max 64 digits

        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
