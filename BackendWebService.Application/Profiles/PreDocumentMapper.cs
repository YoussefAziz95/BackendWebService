using Application.Contracts.Persistences;
using Domain;
namespace Application.Profiles
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


    }
}
