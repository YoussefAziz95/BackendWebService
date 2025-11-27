using Application.Contracts.Persistence;
using Application.Features;
using Domain;
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

            throw new NotImplementedException();
            //var query = from c in _context.Categories
            //            join cf in _context.FileLogs on c.FileId equals cf.Id
            //            where c.OrganizationId == _context.userInfo.OrganizationId
            //            select new CategoryResponse(c.Id, c.Name, c.ParentId, null,
            //                    c.IsActive);

            //return query.Any() ? query.ToList() : null;
        }

        public string GetObjectType(int id)
        {
            var category = _context.Categories.First(t => t.Id == id);
            return category is null ? "" : category.Name;
        }

        public int UpdateCategory(Category updatedEntity)
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
