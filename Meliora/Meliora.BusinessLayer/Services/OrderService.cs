using Meliora.DataLayer.Interfaces;
using Meliora.DataLayer.Model;
using Meliora.DataLayer.RequestModels;

namespace Meliora.BusinessLayer.Services
{
    public class OrderService
    {
        private readonly IOrderDataService _orderDataService;
        public OrderService(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
        }

        public async Task<IEnumerable<Order>> GetOrderHistory(int customerId)
        {
            return await _orderDataService.GetOrderHistory(customerId);
        }

        public async Task<Order> StartOrder(DozenCookiesRequest request)
        {
            return await _orderDataService.StartOrder(request.Dozens, request.CustomerId);
        }

        public async Task<IEnumerable<LineItem>> SubmitOrder(int orderId)
        {
            return await _orderDataService.SubmitOrder(orderId);
        }

        public async Task CancelOrder(int orderId)
        {
            await _orderDataService.CancelOrder(orderId);
        }

        public async Task UncancelOrder(int orderId)
        {
            await _orderDataService.UncancelOrder(orderId);
        }
    }
}
