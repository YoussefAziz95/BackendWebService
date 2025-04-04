using Application.Contracts.DTOs;
using Application.DTOs.SupplierDocuments;

namespace Application.Contracts.Services;

public interface ISupplierDocumentService
{
    Task<IResponse<int>> AddAsync(AddSupplierDocumentRequest request);

    Task<IResponse<SupplierDocumentResponse>> GetAsync(int id);

    Task<IResponse<string>> DeleteAsync(int id);

    Task<IResponse<int>> UpdateAsync(UpdateSupplierDocumentRequest request);

    Task<IResponse<List<SupplierDocumentsResponse>>> GetPaginated(int supplierId);

    bool CheckIdExists(int id);
}
