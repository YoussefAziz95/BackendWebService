using Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Suppliers
{
    /// <summary>
    /// Represents a response model for paginated supplier data.
    /// </summary>
    public class GetPaginatedSupplier
    {
        /// <summary>
        /// Gets or sets the ID of the supplier.
        /// </summary>
        public int Id { get; set; }     
        
        /// <summary>
        /// Gets or sets the ID of the supplier.
        /// </summary>
        public int? SupplierAccountId { get; set; }



        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the key address of the supplier.
        /// </summary>


        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
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
