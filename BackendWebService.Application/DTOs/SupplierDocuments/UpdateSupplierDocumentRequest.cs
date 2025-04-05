using Domain.Enums;
using Domain;
using Application.Validators.Common;
using Application.Profiles;

namespace Application.DTOs.SupplierDocuments
{
    /// <summary>
    /// Represents a request model for updating a supplier document.
    /// </summary>
    public class UpdateSupplierDocumentRequest : BaseValidationModel<UpdateSupplierDocumentRequest>, ICreateMapper<SupplierDocument>
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the URL of the document.
        /// </summary>
        public int? FileId { get; set; }
        public int UserId { get; set; }
    }
}
