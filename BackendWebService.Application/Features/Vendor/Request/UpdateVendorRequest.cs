using Application.Features.Common;
using Application.Features;

namespace Application.Features.Vendor.Request
{
    public class UpdateVendorRequest
    {
        public int Id { get; set; }
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

        public List<UpdateVendorCategoryRequest>? Categories { get; set; }
    }
}
