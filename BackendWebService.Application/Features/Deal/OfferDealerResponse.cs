using Application.Features.Common;

namespace BackendWebService.Application.Features.Deal
{
    public class OfferDealerResponse
    {
        public int Id { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? FinalPrice { get; set; }
        public int? Quantity { get; set; }

        public int? Vat { get; set; }

        public int? Discount { get; set; }

        public string VendorName { get; set; }

        public List<DealDocumentResponse> DealDocuments { get; set; }
        public List<DealDetailsResponse> DealDetails { get; set; }
    }
}
