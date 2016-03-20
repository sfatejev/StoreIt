using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders;
using Domain.Users;

namespace Domain.People
{
    public class Person
    {
        public int PersonId { get; set; }
        public bool PersonActive { get; set; }

        [MaxLength(32)]
        public String Firstname { get; set; }   

        [MaxLength(32)]
        public String Lastname { get; set; }    

        public int PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }

        public virtual List<Contact> Contacts { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<OrderEdit> OrderEdits { get; set; }
        public virtual List<Order> Orders { get; set; }

        [NotMapped]
        public string FirstLastname => (Firstname + " " + Lastname).Trim();        
    }
}
