using Meliora.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meliora.DataLayer.Interfaces
{
    public interface IMixInDataService
    {
        public Task<IEnumerable<Mixins>> GetAll(bool? active);
    }
}
