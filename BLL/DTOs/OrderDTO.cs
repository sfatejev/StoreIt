using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        [XmlAttribute]
        public int OrderId { get; set; }
        public PersonDTO Employee { get; set; }

        public PersonDTO Client { get; set; }

        public string OrderType { get; set; }

        public DateTime PaymentDate { get; set; }

        public List<OrderedProductDTO> OrderedProducts { get; set; }

        public OrderDTO()
        {
        }
    }
}