using System.ComponentModel.DataAnnotations;

namespace BackendWebService.Application.Features.Deal
{
    public class UpdateDealRequest
    {
        public int Id { get; set; }
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

        public List<UpdateDealDocumentRequest> DealDocuments { get; set; }
        public List<UpdateDealDetailsRequest> DealDetails { get; set; }
    }
}
