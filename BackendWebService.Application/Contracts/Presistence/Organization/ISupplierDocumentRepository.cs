using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface ISupplierDocumentRepository
{
    int AddSupplierDocumentAsync(SupplierDocument fullEntity);
    int UpdateSupplierDocument(SupplierDocument updatedEntity);
    IQueryable<SupplierDocumentsResponse> GetPaginated(int CompanyId);
    bool CheckRegistered(int supplierId);
}