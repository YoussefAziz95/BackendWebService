using Application.DTOs.Common;
using Application.DTOs.SupplierCategory;
using Application.DTOs.SupplierDocument;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth.Request
{
    /// <summary>
    /// Represents a request model for registering a supplier.
    /// </summary>
    public class RegisterSupplierRequest
    {
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
        /// </summary>
        public string TaxNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the URL of the supplier's image.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the supplier.
        /// </summary>
        public string? Fax { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the department of the supplier.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the title of the supplier.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the documents of the supplier are approved.
        /// </summary>
        public bool IsDocumentsApproved { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the supplier is approved.
        /// </summary>
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// Gets or sets the categories of the supplier.
        /// </summary>
        public List<AddSupplierCategoryRequest>? Categories { get; set; }
    }
}
