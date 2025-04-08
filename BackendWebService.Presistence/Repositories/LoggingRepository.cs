using Application.Contracts.Persistences;

using Persistence.Data;

namespace Persistence.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly ApplicationDbContext _context;

        public LoggingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddLog(Logging log)
        {
            log.UserId = _context.userInfo is null ? (int?)null : _context.userInfo.OrganizationId;
            _context.Add(log);
            _context.SaveChanges();
        }
    }
}
