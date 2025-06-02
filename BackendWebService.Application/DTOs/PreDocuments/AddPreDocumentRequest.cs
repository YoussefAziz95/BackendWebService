using Application.Validators.Common;
using Application.Profiles;
using Domain;

namespace Application.DTOs.PreDocuments
{
    /// <summary>
    /// Represents a request model for adding a pre document.
    /// </summary>
    public class AddPreDocumentRequest : BaseValidationModel<AddPreDocumentRequest>
    {
        /// <summary>
        /// Gets or sets the name of the pre document.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pre document is required.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether multiple documents of this type are allowed.
        /// </summary>
        public bool IsMultiple { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is local.
        /// </summary>
        public bool IsLocal { get; set; }

        public int FileTypeId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public required int UserId { get; set; }
    }
}
