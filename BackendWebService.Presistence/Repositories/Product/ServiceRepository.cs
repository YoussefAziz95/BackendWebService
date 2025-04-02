using Application.Contracts.Presistence.Product;
using Application.Contracts.Presistence.WorkflowReviewRepositories;

using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Product
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository, IGetObjectType
    {
        public ServiceRepository(ApplicationDbContext context) : base(context) { }

        public string GetObjectType(int id)
        {
            var material = _context.Services.First(t => t.Id == id);
            return material is null ? "" : material.Name;
        }

        public async Task<int> UpdateService(Service updatedEntity)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Service material = GetById(updatedEntity.Id);
                    material.CategoryId = updatedEntity.CategoryId;
                    material.Code= updatedEntity.Code;
                    material.Name = updatedEntity.Name;

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
        private Service GetServiceById(int id)
        {
            return Get(b => b.Id == id,
                            b => b.Include(c => c.Category), disableTracking: false);
        }
        public Service GetById(int id)
        {
            var offer = GetServiceById(id);


            return offer;
        }
    }
}
