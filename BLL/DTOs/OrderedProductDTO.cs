using System.Xml.Serialization;

namespace BLL.DTOs
{
    public class OrderedProductDTO
    {
        [XmlAttribute]
        public int OrderedProductId { get; set; }
        public string OrderedProductName { get; set; }
        public int OrderedQuantity { get; set; }
        public double OrderedPrice { get; set; }

        public OrderedProductDTO()
        {
            
        } 
    }
}