using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BLL.Services;
using DAL;
using DAL.Interfaces.Orders;
using DAL.Repositories.Orders;
using Domain.Orders;
using Domain.People;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            IDbContext ctx = new StoreItDbContext();
            OrderService orderService = new OrderService(ctx);
            orderService.GetOrders();

            orderService.SerializeOrder(orderService.GetOrderById(1));
        }
    }
}
