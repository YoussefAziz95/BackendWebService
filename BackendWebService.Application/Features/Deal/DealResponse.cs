namespace BackendWebService.Application.Features.Deal
{
    public class DealResponse
    {
        public int Id { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? FinalPrice { get; set; }



        public int? Quantity { get; set; }

        public int? Vat { get; set; }

        public int? Discount { get; set; }

        public int OfferId { get; set; }


        public int CompanyVendorId { get; set; }

        public int StatusId { get; set; }

        public List<DealDocumentResponse> DealDocuments { get; set; }
        public List<DealDetailsResponse> DealDetails { get; set; }
    }
}
