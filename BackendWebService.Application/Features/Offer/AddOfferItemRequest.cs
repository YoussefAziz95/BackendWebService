namespace Application.Features
{
    public class AddOfferItemRequest
    {
        public int Quantity { get; set; }
        public int MaterialId { get; set; }
        public int RequiredAmount { get; set; }
        public int DealId { get; set; }
    }
}
