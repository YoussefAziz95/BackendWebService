namespace Application.Features.Deal
{
    public class DealDetailsResponse
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal DetailPrice { get; set; }

        public decimal ItemPrice { get; set; }

        public int DealId { get; set; }

        public int OfferItemId { get; set; }
    }
}
