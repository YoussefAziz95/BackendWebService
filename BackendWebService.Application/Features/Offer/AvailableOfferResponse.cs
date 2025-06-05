using Application.Features.Common;

namespace Application.Features
{
    public class AvailableOfferResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ApplyType { get; set; }

        public DateTime DealCheckDate { get; set; }

        public int DealRequirementsAmount { get; set; }

        public string DealRequirementsDocLink { get; set; } = string.Empty;

        public int InsuranceAmount { get; set; }

        public string OfferCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int DocId { get; set; }

        public int PreDocumentId { get; set; }

        public string DocType { get; set; } = string.Empty;

        public string DocUrl { get; set; } = string.Empty;

        public int TermId { get; set; }

        public string Item { get; set; } = string.Empty;

        public int CatId { get; set; }

        public string Category { get; set; } = string.Empty;

        public int CompCatId { get; set; }
    }
}

