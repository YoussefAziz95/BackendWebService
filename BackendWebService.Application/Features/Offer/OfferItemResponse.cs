namespace BackendWebService.Application.Features
{
    public class OfferItemResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int? RequiredAmount { get; set; }

        public int MaterialId { get; set; }

        public int OfferId { get; set; }
    }
}
