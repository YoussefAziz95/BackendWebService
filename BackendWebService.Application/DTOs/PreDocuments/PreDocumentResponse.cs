using BackendWebService.Application.Profiles;
using System;

using Domain.Enums;
using Domain;
namespace Application.DTOs.PreDocuments
{
    /// <summary>
    /// Represents the response data for a pre document.
    /// </summary>
    public class PreDocumentResponse : ICreateMapper<PreDocument>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the pre document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the pre document.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public int FileTypeId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the pre document is required.
        /// </summary>
        public bool? IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether multiple documents of this type can be uploaded.
        /// </summary>
        public bool? IsMultiple { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the document is stored locally.
        /// </summary>
        public bool? IsLocal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pre document is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date when the pre document was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the pre document was last updated.
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
