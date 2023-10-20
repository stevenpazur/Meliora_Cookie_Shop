using Meliora.DataLayer.Model;
using Meliora.BusinessLayer.Services;
using Meliora.DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Meliora.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _cookieService;
        public ProductController(ProductService cookieService)
        {
            _cookieService = cookieService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _cookieService.GetAll();
        }
    }
}
