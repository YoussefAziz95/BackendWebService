using Application.Profiles;
using Domain;

namespace Application.DTOs.SupplierDocuments
{
    /// <summary>
    /// Represents a supplier document retrieved for pagination.
    /// </summary>
    public class SupplierDocumentsResponse : ICreateMapper<SupplierDocument>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the supplier document.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        public string PreDocumentName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is approved.
        /// </summary>
        public bool? IsApproved { get; set; }

        public int? FileId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the supplier document.
        /// </summary>
        public int PreDocumentId { get; set; }
    }
}
