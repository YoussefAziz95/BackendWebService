using System.ComponentModel.DataAnnotations;

namespace Application.Features.Deal
{
    public class AddDealRequest
    {
        public int OfferId { get; set; }

        public int CompanyVendorId { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? FinalPrice { get; set; }

        [Range(1, 100)]
        public int? Vat { get; set; }

        [Range(1, 100)]
        public int? Discount { get; set; }

        public int? Quantity { get; set; }

        public int? UserId { get; set; }

        public int StatusId { get; set; }

        public List<AddDealDocumentRequest> DealDocuments { get; set; }
        public List<AddDealDetailsRequest> DealDetails { get; set; }
    }
}
