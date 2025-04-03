using Application.DTOs.Categories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.Product
{
    public interface ICategoryRepository
    {
        List<CategoryResponse> GetAll(int CompanyId);
        Task<int> UpdateCategory(Category updatedEntity);
        Category GetById(int id);
    }
}
