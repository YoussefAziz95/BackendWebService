using BackendWebService.Application.Profiles;
using Domain;
using System;

namespace Application.DTOs.SupplierDocuments
{
    /// <summary>
    /// Represents a response model for supplier documents.
    /// </summary>
    public class SupplierDocumentResponse : ICreateMapper<SupplierDocument>
    {
        /// <summary>
        /// Gets or sets the ID of the supplier document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the supplier associated with the document.
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier associated with the document.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the pre document associated with the document.
        /// </summary>
        public int PreDocumentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the pre document associated with the document.
        /// </summary>
        public string PreDocumentName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the document.
        /// </summary>
        public string DocUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the document was last updated.
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
