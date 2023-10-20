using Meliora.DataLayer.Model;
using static Meliora.DataLayer.RequestModels.DozenCookiesRequest;

namespace Meliora.DataLayer.Interfaces
{
    public interface IOrderDataService
    {
        public Task<IEnumerable<Order>> GetOrderHistory(int customerId);
        public Task<Order> StartOrder(IEnumerable<BaseProductRequest> request, int customerId);
        public Task<IEnumerable<LineItem>> SubmitOrder(int orderId);
        public Task CancelOrder(int orderId);
        public Task UncancelOrder(int orderId);
    }
}
