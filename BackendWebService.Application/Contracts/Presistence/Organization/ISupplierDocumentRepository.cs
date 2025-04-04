using Application.DTOs.SupplierDocuments;
using Domain;

namespace Application.Contracts.Persistences;

public interface ISupplierDocumentRepository
{
    int AddSupplierDocumentAsync(SupplierDocument fullEntity);
    int UpdateSupplierDocument(SupplierDocument updatedEntity);
    IQueryable<SupplierDocumentsResponse> GetPaginated(int CompanyId);
    bool CheckRegistered(int supplierId);
}