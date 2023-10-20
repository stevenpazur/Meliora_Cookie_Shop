using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Meliora.DataLayer.Model
{
    public partial class LineItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? ProductMixinMapId { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; } = null!;
        public virtual Product? Product { get; set; }
    }
}
