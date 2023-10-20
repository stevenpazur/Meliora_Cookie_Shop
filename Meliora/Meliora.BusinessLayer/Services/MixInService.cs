using Meliora.DataLayer.Model;
using Meliora.DataLayer.Interfaces;

namespace Meliora.BusinessLayer.Services
{
    public class MixInService
    {
        private readonly IMixInDataService _mixInDataService;
        public MixInService(IMixInDataService mixInDataService)
        {
            _mixInDataService = mixInDataService;
        }

        public async Task<IEnumerable<Mixins>> GetAll(bool? active)
        {
            return await _mixInDataService.GetAll(active);
        }
    }
}
