using Domain;
using Persistence.Data;

namespace Persistence.Repositories.Notifications
{
    public class NotificationDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(NotificationDetail fullEntity)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    fullEntity.ExpiryDate = DateTime.UtcNow.AddDays(30);

                    _context.Add(fullEntity);
                    _context.SaveChanges();

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
    }
}
