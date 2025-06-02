using Domain.Enums;
using Domain;
using Application.Validators.Common;
using Application.Profiles;

namespace Application.DTOs.SupplierDocuments
{
    /// <summary>
    /// Request data transfer object for adding a supplier document.
    /// </summary>
    public class AddSupplierDocumentRequest:BaseValidationModel<AddSupplierDocumentRequest>
    {

        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the company associated with the document.
        /// </summary>
        public int CompanyId { get; set; }

        public int FileId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the pre document.
        /// </summary>
        public int PreDocumentId { get; set; }
    }
}
