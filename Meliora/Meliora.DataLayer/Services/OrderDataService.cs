using Meliora.DataLayer.Interfaces;
using Meliora.DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using static Meliora.DataLayer.RequestModels.DozenCookiesRequest;

namespace Meliora.DataLayer.Services
{
    public class OrderDataService : IOrderDataService
    {
        private readonly SONQuizContext _context;
        public OrderDataService(SONQuizContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrderHistory(int customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        private decimal GetTotalPrice(IEnumerable<BaseProductRequest> products)
        {
            decimal total = 0;
            foreach (var productRequest in products)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productRequest.ProductId) ?? new Product() { Price = 0 };
                var mixins = _context.Mixins.Where(m => productRequest.MixinIds.ToList().Contains(m.Id)).ToList();
                total += product.Price * productRequest.Quantity;
                foreach (var mixin in mixins)
                {
                    total += mixin.Price.GetValueOrDefault() * productRequest.Quantity;
                }
            }

            return total;
        }

        public async Task<Order> StartOrder(IEnumerable<BaseProductRequest> baseProductRequests, int customerId)
        {
            // find customer
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
            {
                throw new InvalidDataException("Cannot find customer with Id " + customerId);
            }

            // start delivery plan
            Delivery delivery = new Delivery()
            {
                DeliveryDate = null,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                City = customer.City,
                State = customer.State,
                Zip = customer.Zip,
                Country = customer.Country
            };
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();

            Order order = new Order()
            {
                DeliveryId = delivery.Id,
                CustomerId = customer.Id,
                Status = "Started",
                TotalPrice = GetTotalPrice(baseProductRequests)
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // create product mixin map
            // find the next Id
            var mapList = await _context.ProductMixinMaps.ToListAsync();
            var mapId = mapList.Count() + 1;
            // create the mixin maps
            var newMaps = new List<ProductMixinMap>();
            // also start a list of line items
            var lineItems = new List<LineItem>();
            foreach (var bpr in baseProductRequests)
            {
                foreach (var mixinId in bpr.MixinIds)
                {
                    var newMap = new ProductMixinMap()
                    {
                        MapId = mapId,
                        MixinId = mixinId
                    };
                    newMaps.Add(newMap);

                    var lineItem = new LineItem()
                    {
                        ProductId = bpr.ProductId,
                        OrderId = order.Id,
                        ProductMixinMapId = mapId,
                        Quantity = bpr.Quantity
                    };
                    lineItems.Add(lineItem);
                }
            }

            // add the product mixin maps
            if (newMaps.Count() > 0)
            {
                await _context.ProductMixinMaps.AddRangeAsync(newMaps);
                await _context.SaveChangesAsync();
            }

            // add the line items
            if (lineItems.Count() > 0)
            {
                await _context.LineItems.AddRangeAsync(lineItems);
                await _context.SaveChangesAsync();
            }

            // if all goes well, save the changes
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<LineItem>> SubmitOrder(int orderId)
        {
            // update the order status
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Cannot find order with orderID " + orderId);
            }

            order.Status = "Submitted";
            await _context.SaveChangesAsync();

            return await _context.LineItems.Where(x => x.OrderId == orderId).ToListAsync();
        }

        public async Task CancelOrder(int orderId)
        {
            // set the status of the order to Cancelled
            Order order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Cannot find order with orderID " + orderId);
            }

            order.Status = "Cancelled";
            await _context.SaveChangesAsync();
        }

        public async Task UncancelOrder(int orderId)
        {
            // set the status of the order back to Submitted
            Order order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Cannot find order with orderID " + orderId);
            }

            order.Status = "Submitted";
            await _context.SaveChangesAsync();
        }
    }
}
