using Application.DTOs.Common;
using Application.Validators.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Company.Request
{
    /// <summary>
    /// Represents a request model for adding a company.
    /// </summary>
    public class AddCompanyRequest : BaseValidationModel<AddCompanyRequest>
    {
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the company.
        /// </summary>
        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the tax number of the company.
        /// </summary>
        public string TaxNo { get; set; }

        /// <summary>
        /// Gets or sets the email of the company.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with the company.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the company.
        /// </summary>
        public string? Fax { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the company.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company type.
        /// </summary>
        public int? RoleId { get; set; }
    }
}
