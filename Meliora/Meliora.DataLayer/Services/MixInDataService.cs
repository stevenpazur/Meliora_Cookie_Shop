using Meliora.DataLayer.Model;
using Meliora.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meliora.DataLayer.Services
{
    public class MixInDataService : IMixInDataService
    {
        private readonly SONQuizContext _dbContext;
        public MixInDataService(SONQuizContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Mixins>> GetAll(bool? active)
        {
            if (active == null)
            {
                return await _dbContext.Mixins.AsNoTracking().ToListAsync();
            }
            return await _dbContext.Mixins.AsNoTracking().Where(x => x.Active == active.GetValueOrDefault()).ToListAsync();
        }
    }
}
