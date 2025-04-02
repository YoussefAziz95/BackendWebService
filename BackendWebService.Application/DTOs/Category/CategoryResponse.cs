using Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Category
{
    /// <summary>
    /// Represents a response model for a category.
    /// </summary>
    public class CategoryResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the parent category, if any.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the category is active.
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
