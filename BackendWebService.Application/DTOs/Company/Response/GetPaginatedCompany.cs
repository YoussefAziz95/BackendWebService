using Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Supplier.Responses
{
    /// <summary>
    /// Represents a response model for paginated supplier data.
    /// </summary>
    public class GetPaginatedCompany
    {
        /// <summary>
        /// Gets or sets the ID of the supplier.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the key address of the supplier.
        /// </summary>
        public string RoleType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the email of the supplier.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the tax number of the supplier.
        /// </summary>
        public string TaxNo { get; set; }
    }
}
