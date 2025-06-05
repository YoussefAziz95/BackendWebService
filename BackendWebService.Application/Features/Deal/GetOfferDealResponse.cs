using Application.Features.Common;

namespace BackendWebService.Application.Features.Deal
{
    public class GetOfferDealResponse
    {
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public List<GetOfferDealDocumentResponse> DealDocuments { get; set; }
        public List<GetOfferDealDetailsResponse> DealDetails { get; set; }

    }
}
