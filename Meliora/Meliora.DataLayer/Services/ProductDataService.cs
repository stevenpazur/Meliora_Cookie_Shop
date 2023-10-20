using Meliora.DataLayer.Model;
using Meliora.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meliora.DataLayer.Services
{
    public class ProductDataService : IProductDataService
    {
        private readonly SONQuizContext _context;
        public ProductDataService(SONQuizContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var toReturn = await _context.Products
                .ToListAsync();

            return toReturn;
        }
    }
}
