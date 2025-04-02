using Application.DTOs.SupplierDocument;


namespace Application.Contracts.Presistence.Organization
{
    public interface ISupplierDocumentRepository
    {
        /// <summary>
        /// Adds a new <see cref="SupplierDocument"/> entity with the specified data.
        /// </summary>
        /// <param name="fullEntity">The new entity data.</param>
        /// <returns>The added <see cref="SupplierDocument"/>.</returns>
        int AddSupplierDocumentAsync(SupplierDocument fullEntity);

        /// <summary>
        /// Updates a <see cref="SupplierDocument"/> entity with the specified ID and updated data.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="updatedEntity">The updated entity data.</param>
        /// <returns>The updated <see cref="SupplierDocument"/>.</returns>
        int UpdateSupplierDocument(SupplierDocument updatedEntity);

        IQueryable<SupplierDocumentsResponse> GetPaginated(int CompanyId);
        bool CheckRegistered(int supplierId);
    }
}
