using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Notification.Request
{
    /// <summary>
    /// Represents the details of a notification to be included in the add request.
    /// </summary>
    public class NotificationDetailRequest
    {
        /// <summary>
        /// Gets or sets the channel through which the notification is sent.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the ID of the notified actor.
        /// </summary>
        public int NotifiedId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been read.
        /// </summary>
        public bool IsRead { get; set; } = false;
    }
}
