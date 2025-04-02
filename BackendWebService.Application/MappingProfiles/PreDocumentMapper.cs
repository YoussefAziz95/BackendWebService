using Application.Contracts.Presistence;
using Application.DTOs.PreDocument;


namespace Application.MappingProfiles
{
    /// <summary>
    /// Static class containing methods to map pre document-related entities and DTOs.
    /// </summary>
    public static class PreDocumentMapper
    {
        /// <summary>
        /// Retrieves a pre document entity by ID.
        /// </summary>
        /// <param name="id">The ID of the pre document to retrieve.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        /// <returns>The retrieved pre document entity.</returns>
        public static PreDocument GetPreDocument(int id, IUnitOfWork unitOfWork)
        {
            return unitOfWork.GenericRepository<PreDocument>().GetById(id);
        }

        /// <summary>
        /// Maps a pre document entity to a pre document response DTO.
        /// </summary>
        /// <param name="id">The ID of the pre document to map.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        /// <returns>The mapped pre document response DTO.</returns>
        public static PreDocumentResponse GetPreDocumentResponse(int id, IUnitOfWork unitOfWork)
        {
            var entity = GetPreDocument(id, unitOfWork);
            var response = new PreDocumentResponse()
            {
                Id = id,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsActive,
                IsLocal = entity.IsLocal,
                IsRequired = entity.IsRequired,
                IsMultiple = entity.IsMultiple,
                Name = entity.Name,
                UpdateDate = entity.UpdateDate
            };
            return response;
        }
    }
}
