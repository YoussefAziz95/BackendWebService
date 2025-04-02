using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Notifications
{
    /// <summary>
    /// Represents the response of a notification in the system.
    /// </summary>
    public class NotificationResponse : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the notification that this response is related to.
        /// </summary>
        public int NotificationId { get; set; }


        [Required]
        public string MessageTitle { get; set; }

        [Required]
        public string MessageBody { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user who responded to the notification.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the status of the notification response (e.g., viewed, acknowledged).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a timestamp for when the notification response was created.
        /// </summary>
        public DateTime ResponseTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the channel through which the response was received (e.g., mobile app, email).
        /// </summary>
        public string ResponseChannel { get; set; }

        /// <summary>
        /// Navigation property for the user who created the notification.
        /// </summary>
        public string Notifier { get; set; }

        /// <summary>
        /// Navigation property for the notification type.
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Navigation property for the notification object.
        /// </summary>
        public string NotificationObjectType { get; set; }
    }
}
