using Application.DTOs.Common;
using Application.Profiles;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Companies
{
    /// <summary>
    /// Represents the response data for a company.
    /// </summary>
    public class CompanyResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the company.
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the email address of the company.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the tax number of the company.
        /// </summary>
        public string TaxNo { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the company.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the URL of the company's image.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the company.
        /// </summary>
        public string? Fax { get; set; }

        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the company is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date when the company was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the company was last updated.
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
