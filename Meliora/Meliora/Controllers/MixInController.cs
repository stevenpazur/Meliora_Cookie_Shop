using Meliora.DataLayer.Model;
using Meliora.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meliora.api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MixInController : Controller
    {
        private readonly MixInService _mixInService;
        public MixInController(MixInService mixInService)
        {
            _mixInService = mixInService;
        }

        /// <summary>
        /// Gets all mixins based on active value
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IEnumerable<Mixins>> GetMixInList(bool? active)
        {
            return await _mixInService.GetAll(active);
        }
    }
}
