using Microsoft.AspNetCore.Mvc;
using OrderProcessingService.Models;
using System.Collections.Generic;

namespace OrderProcessingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>
        {
            new Order { Id = 1, OrderDate = DateTime.Now, CustomerName = "Customer1", ProductIds = new List<int> { 1, 2 } }
        };

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return Orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = Orders.Find(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }
    }
}

