using Meliora.BusinessLayer.Services;
using Meliora.DataLayer.Model;
using Meliora.DataLayer.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Meliora.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("OrderHistory/{customerId}")]
        public async Task<IEnumerable<Order>> GetOrderHistory(int customerId)
        {
            return await _orderService.GetOrderHistory(customerId);
        }

        [HttpPost("StartOrder")]
        public async Task<Order> StartOrder([FromBody] DozenCookiesRequest order)
        {
            return await _orderService.StartOrder(order);
        }

        [HttpPut("SubmitOrder/{orderId}")]
        public async Task<IEnumerable<LineItem>> SubmitOrder(int orderId)
        {
            return await _orderService.SubmitOrder(orderId);
        }

        [HttpPut("CancelOrder/{orderId}")]
        public async Task CancelOrder(int orderId)
        {
            await _orderService.CancelOrder(orderId);
        }

        [HttpPut("UncancelOrder/{orderid}")]
        public async Task UncancelOrder(int orderId)
        {
            await _orderService.UncancelOrder(orderId);
        }
    }
}
