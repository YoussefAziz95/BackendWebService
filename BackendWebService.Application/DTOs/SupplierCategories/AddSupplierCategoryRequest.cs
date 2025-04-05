using Application.Validators.Common;
using Application.Profiles;
using Domain;
namespace Application.DTOs.SupplierCategories
{
    /// <summary>
    /// Request data transfer object for adding a supplier category.
    /// </summary>
    public class AddSupplierCategoryRequest : BaseValidationModel<AddSupplierCategoryRequest>, ICreateMapper<SupplierCategory>
    {
        /// <summary>
        /// Gets or sets the Companies ID.
        /// </summary>
        /// <value>
        /// The ID of the company associated with the supplier category.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Categories ID.
        /// </summary>
        /// <value>
        /// The ID of the category being added for the supplier.
        /// </value>
        public int CategoryId { get; set; }
    }
}
