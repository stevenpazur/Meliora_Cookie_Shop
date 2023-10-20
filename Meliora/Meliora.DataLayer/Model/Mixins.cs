using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meliora.DataLayer.Model
{
    public class Mixins
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Active { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; } = 0;
        public int? ProductId { get; set; } = null;
    }
}
