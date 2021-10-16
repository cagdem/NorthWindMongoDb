using Infrastructure;
using Infrastructure.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NW_MongoDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoDbController : ControllerBase
    {


        [HttpGet]
        public OrderDto Get(int orderId)
        {
            MongoCRUD db = new MongoCRUD("NortWindTest");
            using (var context = new NORTHWNDContext())
            {
                Order order = context.Orders.Find(orderId);
                //context.Entry(order).Collection("OrderDetails").Load();
                context.Orders.Include("OrderDetails").First(o => o.OrderId == orderId);
                //order.Adapt(dto);
                
                //Loopu cozme denemeleriydi bunlar

                OrderDto dto = new OrderDto {
                    Customer = order.Customer,
                    CustomerId = order.CustomerId,
                    Employee = order.Employee,
                    EmployeeId = order.EmployeeId,
                    Freight = order.Freight,
                    OrderDate = order.OrderDate,
                    OrderDetails = order.OrderDetails,
                    OrderId = order.OrderId,
                    RequiredDate = order.RequiredDate,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipCountry = order.ShipCountry,
                    ShipName = order.ShipName,
                    ShippedDate = order.ShippedDate,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipRegion = order.ShipRegion,
                    ShipVia = order.ShipVia,
                    ShipViaNavigation = order.ShipViaNavigation

                };

                db.InsertRecord("Orders", dto);
                return dto;
            }
            
        }
    }
}
