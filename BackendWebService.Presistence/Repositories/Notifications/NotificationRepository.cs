using Application.Contracts.Persistence.Notifications;
using Domain;
using Persistence.Data;

namespace Persistence.Repositories.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Notification fullEntity)
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
            return fullEntity.Id;
        }

        public int AddDetailsAsync(string username, int notificationId)
        {

            var result = -1;


            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = _context.Users.Select(u => new { u.UserName, u.Id, u.OrganizationId }).First(u => u.UserName == username);
                    var fullEntity = new NotificationDetail()
                    {
                        Channel = "Notifications",
                        NotificationId = notificationId,
                        UserId = user.Id,
                        IsRead = false,
                        OrganizationId = user.OrganizationId
                    };

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
