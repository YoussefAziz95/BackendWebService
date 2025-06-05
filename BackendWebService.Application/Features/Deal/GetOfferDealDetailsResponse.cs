using Application.Features.Common;

namespace BackendWebService.Application.Features.Deal
{
    public class GetOfferDealDetailsResponse
    {

        public int OfferItemId { get; set; }
        public string OfferItemName { get; set; }
        public int OfferItemQuantity { get; set; }
    }
}
