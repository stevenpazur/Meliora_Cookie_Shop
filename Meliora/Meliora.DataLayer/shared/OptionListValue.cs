using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meliora.BusinessLayer.shared
{
    public class OptionListValue<T> where T : Enum
    {
        public int Id { get; set; }
        public T Value { get; set; }
        public string DisplayValue { get; set; }
    }
}
