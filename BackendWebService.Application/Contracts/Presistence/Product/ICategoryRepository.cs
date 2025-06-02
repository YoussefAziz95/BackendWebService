using Application.DTOs;
using Domain;

namespace Application.Contracts.Persistences;

public interface ICategoryRepository
{
    List<CategoryResponse> GetAll(int CompanyId);
    Task<int> UpdateCategory(Category updatedEntity);
    Category GetById(int id);
}
