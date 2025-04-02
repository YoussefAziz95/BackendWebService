using Application.Validators.Common;

namespace Application.DTOs.SupplierCategory
{
    /// <summary>
    /// Request data transfer object for adding a supplier category.
    /// </summary>
    public class AddSupplierCategoryRequest : BaseValidationModel<AddSupplierCategoryRequest>
    {
        /// <summary>
        /// Gets or sets the Company ID.
        /// </summary>
        /// <value>
        /// The ID of the company associated with the supplier category.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Category ID.
        /// </summary>
        /// <value>
        /// The ID of the category being added for the supplier.
        /// </value>
        public int CategoryId { get; set; }
    }
}
