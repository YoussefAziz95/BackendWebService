using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Deals
{
    public class Deal : BaseEntity
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int OfferId { get; set; }

        public int? UserId { get; set; } // Nullable in case it's not linked to a user

        [Required]
        public int CompanyVendorId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Total price must be a positive value.")]
        public decimal? TotalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Final price must be a positive value.")]
        public decimal? FinalPrice { get; set; }

        [Range(0, 100, ErrorMessage = "VAT percentage must be between 0 and 100.")]
        public int? Vat { get; set; }

        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public int? Discount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int? Quantity { get; set; }

        public int? StatusId { get; set; }

        // Navigation properties
        public List<DealDocument> DealDocuments { get; set; } = new();
        public List<DealDetails> DealDetails { get; set; } = new();
    }
}
