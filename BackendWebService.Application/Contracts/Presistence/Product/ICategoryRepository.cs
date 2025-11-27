using Application.Features;
using Domain;

namespace Application.Contracts.Persistence;

public interface ICategoryRepository
{
    List<CategoryResponse> GetAll(int CompanyId);
    int UpdateCategory(Category updatedEntity);
    Category GetById(int id);
}
