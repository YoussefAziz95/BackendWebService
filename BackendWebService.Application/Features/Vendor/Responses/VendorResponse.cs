using Application.Features;

namespace Application.Features.Vendor.Responses
{
    public class VendorResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string Email { get; set; }

        public string TaxNo { get; set; }

        public string? Phone { get; set; }

        public string? ImageUrl { get; set; }

        public string? Fax { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public bool IsDocumentsApproved { get; set; }

        public bool IsApproved { get; set; }

        public List<VendorCategoryResponse>? Categories { get; set; }

        public string? Department { get; set; }

        public string? Title { get; set; }
    }
}
