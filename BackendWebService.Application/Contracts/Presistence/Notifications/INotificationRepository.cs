

namespace Application.Contracts.Presistence.Notifications
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Adds a new notification to the database.
        /// </summary>
        /// <param name="fullEntity">The notification entity to add.</param>
        /// <returns>The result of the operation (e.g., the number of affected rows).</returns>
        Task<int> AddAsync(Notification fullEntity);

        /// <summary>
        /// Retrieves a list of notifications for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user whose notifications to retrieve.</param>
        /// <returns>A list of notifications for the user.</returns>
        int AddDetailsAsync(string username, int notificationId);
    }
}
