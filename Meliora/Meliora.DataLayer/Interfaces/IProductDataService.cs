using Meliora.DataLayer.Model;

namespace Meliora.DataLayer.Interfaces
{
    public interface IProductDataService
    {
        public Task<IEnumerable<Product>> GetAll();
    }
}
