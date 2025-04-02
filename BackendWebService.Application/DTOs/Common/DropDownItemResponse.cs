using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a response model for a dropdown item.
    /// </summary>
    public class DropDownItemResponse
    {
        /// <summary>
        /// Gets or sets the ID of the dropdown item.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the list of key resource responses associated with the dropdown item.
        /// </summary>
        [Required]
        public string KeyRescource { get; set; }
    }
}
