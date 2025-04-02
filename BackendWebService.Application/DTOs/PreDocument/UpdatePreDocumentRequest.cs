using Application.Validators.Common;

namespace Application.DTOs.PreDocument
{
    /// <summary>
    /// Represents a request model used to update pre document details.
    /// </summary>
    public class UpdatePreDocumentRequest : BaseValidationModel<UpdatePreDocumentRequest>
    {
        /// <summary>
        /// Gets or sets the identifier of the pre document.
        /// </summary>
        public required int id { get; set; }

        /// <summary>
        /// Gets or sets the name of the pre document.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pre document is required.
        /// </summary>
        /// 
        public int FileTypeId { get; set; }
        public bool? IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether multiple documents of this type are allowed.
        /// </summary>
        public bool? IsMultiple { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pre document is local.
        /// </summary>
        public bool? IsLocal { get; set; }
    }
}
