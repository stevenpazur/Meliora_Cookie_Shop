using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Meliora.DataLayer.Model
{
    public partial class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryId { get; set; }
        public string? Status { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; } = null!;
    }
}
