using System.ComponentModel.DataAnnotations;

namespace Meliora.DataLayer.Model
{
    public partial class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string AddressLine1 { get; set; } = null!;
        [StringLength(50)]
        public string? AddressLine2 { get; set; }
        [StringLength(50)]
        public string City { get; set; } = null!;
        [StringLength(50)]
        public string State { get; set; } = null!;
        [StringLength(50)]
        public string Zip { get; set; } = null!;
        [StringLength(50)]
        public string Country { get; set; } = null!;
    }
}
