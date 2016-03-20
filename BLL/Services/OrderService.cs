using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using BLL.DTOs;
using BLL.Factories;
using DAL;
using DAL.Interfaces.Orders;
using DAL.Repositories.Orders;
using Domain.Orders;
using Domain.People;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly DTOFactory _dto;
        private readonly IOrderRepository _orderRepo;

        public OrderService(IDbContext dbContext)
        {
            _dto = new DTOFactory();
            _orderRepo = new OrderRepository(dbContext);
        }

        public List<OrderDTO> GetOrders()
        {
            return _orderRepo.All.Select(o => _dto.CreateOrderDTO(o)).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            return _dto.CreateOrderDTO(_orderRepo.GetById(id));
        }

        public void SerializeOrder(OrderDTO order)
        {
            using (StreamWriter streamer = new StreamWriter("arved.xml"))
            {
                XmlSerializer xmler = new XmlSerializer(typeof(OrderDTO));
                xmler.Serialize(streamer, order);
            }
        }
    }
}