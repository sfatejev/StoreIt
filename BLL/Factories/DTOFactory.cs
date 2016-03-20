using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOs;
using Domain.Orders;
using Domain.People;

namespace BLL.Factories
{
    public class DTOFactory
    {
        public OrderDTO CreateOrderDTO(Order order)
        {
            return new OrderDTO()
            {
                OrderId = order.OrderId,
                Employee = CreatePersonDTO(order.Employee),
                Client = CreatePersonDTO(order.Client),
                OrderType = order.OrderType.OrderTypeValue,
                PaymentDate = order.OrderPaymentDate,
                OrderedProducts = order.OrderedProducts.Select(CreateOrderedProductDTO).ToList()
            };
        }

        public ContactDTO CreateContactDTO(Contact contact)
        {
            return new ContactDTO()
            {
                ContactValue = contact.ContactValue,
                ContactTypeValue = contact.ContactType.ContactTypeValue
            };
        }

        public PersonDTO CreatePersonDTO(Person person)
        {
            return new PersonDTO()
            {
                FullName = person.FirstLastname,
                MainContact = CreateContactDTO(person.Contacts[0])
            };
        }

        public OrderedProductDTO CreateOrderedProductDTO(OrderedProduct orderedProduct)
        {
            return new OrderedProductDTO()
            {
                OrderedProductId = orderedProduct.OrderedProductId,
                OrderedProductName = orderedProduct.Product.ProductName,
                OrderedQuantity = orderedProduct.OrderedQuantity,
                OrderedPrice = orderedProduct.OrderedPrice
            };
        }
    }
}