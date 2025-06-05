using Application.Features.Common;
using Application.Features;
using Application.Features;

namespace Application.Features.Vendor.Request
{
    public class AddVendorRequest
    {
        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        public required string TaxNo { get; set; }

        public required string Email { get; set; }

        public string? ImageUrl { get; set; }

        public string? Fax { get; set; }

        public string? Phone { get; set; }

        public string? Department { get; set; }

        public string? Title { get; set; }

        public bool IsDocumentsApproved { get; set; } = false;

        public bool IsApproved { get; set; } = false;
        public List<AddVendorCategoryRequest>? vendorCategories { get; set; }

    }
}
