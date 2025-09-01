using Application.Features;
namespace Application.Contracts.Persistence;

public interface ISupplierDocumentRepository
{
    int AddSupplierDocumentAsync(SupplierDocument fullEntity);
    int UpdateSupplierDocument(SupplierDocument updatedEntity);
    IQueryable<SupplierDocumentAllResponse> GetPaginated(int CompanyId);
    bool CheckRegistered(int supplierId);
}