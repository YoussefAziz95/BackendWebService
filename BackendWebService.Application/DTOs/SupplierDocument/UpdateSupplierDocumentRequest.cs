using Application.Validators.Common;

namespace Application.DTOs.SupplierDocument
{
    /// <summary>
    /// Represents a request model for updating a supplier document.
    /// </summary>
    public class UpdateSupplierDocumentRequest : BaseValidationModel<UpdateSupplierDocumentRequest>
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the URL of the document.
        /// </summary>
        public int? FileId { get; set; }
        public int UserId { get; set; }
    }
}
