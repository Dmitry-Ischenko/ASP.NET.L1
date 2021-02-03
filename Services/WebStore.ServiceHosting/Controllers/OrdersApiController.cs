using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces;
using Webstore.Interfaces.Services;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase, IOrderService
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersApiController> logger;

        public OrdersApiController(IOrderService orderService, ILogger<OrdersApiController> Logger)
        {
            this.orderService = orderService;
            logger = Logger;
        }

        [HttpPost("{UserName}")]
        public async Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel)
        {
            return await orderService.CreateOrder(UserName, OrderModel);
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> GetOrderById(int id)
        {
            return await orderService.GetOrderById(id);
        }
        [HttpGet("user/{UserName}")]
        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName)
        {
            return await orderService.GetUserOrders(UserName);
        }
    }
}
