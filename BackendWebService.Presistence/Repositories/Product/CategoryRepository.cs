using Application.Contracts.Presistence.Product;
using Application.Contracts.Presistence.WorkflowReviewRepositories;
using Application.DTOs.Category;
using Application.DTOs.Common;

using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Product
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository, IGetObjectType
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        public List<CategoryResponse> GetAll(int CompanyId)
        {
            var query = from c in _context.Categories
                        where c.OrganizationId == _context.userInfo.OrganizationId
                        select new CategoryResponse
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ParentId = c.ParentId
                        };
            return query.Any() ? query.ToList() : null;
        }

        public string GetObjectType(int id)
        {
            var category = _context.Categories.First(t => t.Id == id);
            return category is null ? "" : category.Name;
        }

        public async Task<int> UpdateCategory(Category updatedEntity)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Category category = GetById(updatedEntity.Id);
                    category.ParentId = updatedEntity.ParentId;


                    result = _context.SaveChanges();

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    throw;
                }
            }
            return result;
        }
        private Category GetCategoryById(int id)
        {
            return Get(b => b.Id == id,
                            b => b.Include(c => c.ParentCategory), disableTracking: false);
        }
        public Category GetById(int id)
        {
            var offer = GetCategoryById(id);


            return offer;
        }

    }
}
