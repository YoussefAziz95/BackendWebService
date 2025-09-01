using Application.Contracts.Features;
using Application.Features;
namespace Application.Contracts.Services;
public interface IPreDocumentService
{
    Task<IResponse<PreDocumentResponse>> AddAsync(AddPreDocumentRequest request);
    Task<IResponse<PreDocumentResponse>> GetAsync(int id);
    Task<IResponse<string>> DeleteAsync(int id);
    Task<IResponse<PreDocumentResponse>> UpdateAsync(int id, UpdatePreDocumentRequest request);
    Task<PaginatedResponse<PreDocumentResponse>> GetPaginated(GetPaginatedPreDocument request);
    Task<IResponse<IEnumerable<PreDocumentResponse>>> GetAllAsync();
    bool CheckIdExists(int id);
}
