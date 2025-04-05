using Application.DTOs.SupplierCategories;
using Application.Validators.Common;
using Application.Profiles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Companies
{
    /// <summary>
    /// Represents a request model used to edit company details.
    /// </summary>
    public class UpdateCompanyRequest : BaseValidationModel<UpdateCompanyRequest>, ICreateMapper<Company>
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the tax number of the supplier.
        /// This field is required.
        /// </summary>
        public required string TaxNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// This field is required.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the URL of the supplier's image.
        /// This field is optional.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the supplier.
        /// This field is optional.
        /// </summary>
        public string? Fax { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// This field is optional.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the department of the supplier.
        /// This field is optional.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the title of the supplier.
        /// This field is optional.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the list of categories associated with the supplier.
        /// This field is optional.
        /// </summary>
        public List<UpdateSupplierCategoryRequest>? Categories { get; set; }
    }
}
