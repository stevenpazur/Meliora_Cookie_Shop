using Meliora.DataLayer.Model;
using Meliora.DataLayer.Interfaces;

namespace Meliora.BusinessLayer.Services
{
    public class ProductService
    {
        private readonly IProductDataService _cookieDataService;
        public ProductService(IProductDataService cookieDataService)
        {
            _cookieDataService = cookieDataService;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _cookieDataService.GetAll();
        }
    }
}
