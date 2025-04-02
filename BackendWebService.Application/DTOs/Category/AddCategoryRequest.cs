using Application.DTOs.Common;
using Application.Validators.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Category
{
    /// <summary>
    /// Request model for adding a category.
    /// </summary>
    public class AddCategoryRequest : BaseValidationModel<AddCategoryRequest>
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent category, if any.
        /// </summary>
        public int? ParentId { get; set; }
    }
}
