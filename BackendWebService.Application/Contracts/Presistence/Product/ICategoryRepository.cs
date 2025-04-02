using Application.DTOs.Category;


namespace Application.Contracts.Presistence.Product
{
    public interface ICategoryRepository
    {
        List<CategoryResponse> GetAll(int CompanyId);
        Task<int> UpdateCategory(Category updatedEntity);
        Category GetById(int id);
    }
}
