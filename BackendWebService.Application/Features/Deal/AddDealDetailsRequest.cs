namespace Application.Features.Deal
{
    public class AddDealDetailsRequest
    {
        public int Quantity { get; set; }

        public decimal DetailPrice { get; set; }

        public decimal ItemPrice { get; set; }

        public int OfferItemId { get; set; }

    }
}
