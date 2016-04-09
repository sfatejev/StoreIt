using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.People
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        
        [MaxLength(64)]
        public MultiLangString PersonTypeValue { get; set; }
        public MultiLangString PersonTypeDescription { get; set; }
        public bool PersonTypeActive { get; set; }

        public virtual List<Person> Persons { get; set; }
    }
}
