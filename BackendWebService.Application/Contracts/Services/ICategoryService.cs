using Application.Contracts.DTOs;
using Application.DTOs;

namespace Application.Contracts.Services;

public interface ICategoryService
{
    Task<IResponse<int>> AddAsync(AddCategoryRequest request);
    Task<IResponse<CategoryResponse>> GetAsync(int id);
    Task<IResponse<string>> DeleteAsync(int id);
    Task<IResponse<int>> UpdateAsync(UpdateCategoryRequest request);
    Task<IResponse<List<CategoryResponse>>> GetPaginated(int CompanyId);
    bool CheckIdExists(int id);
}
