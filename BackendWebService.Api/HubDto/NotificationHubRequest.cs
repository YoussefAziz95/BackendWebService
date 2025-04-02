using Application.DTOs.Common;
using Application.DTOs.Notification.Request;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Notification
{
    public class NotificationHubRequest
    {

        /// <summary>
        /// Gets or sets the title of the notification message.
        /// </summary>
        [Required]
        public string MessageTitle { get; set; }

        /// <summary>
        /// Gets or sets the body content of the notification message.
        /// </summary>
        [Required]
        public string MessageBody { get; set; }

        /// <summary>
        /// Gets or sets the priority of the notification.
        /// </summary>

        public string Priority { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the notification.
        /// </summary>

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the expiry date of the notification.
        /// </summary>

        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the notifier (user creating the notification).
        /// </summary>
        /// <summary>
        /// Gets or sets the ID of the user who created the notification.
        /// </summary>
        public int NotifierId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user or entity being notified.
        /// </summary>
        public int NotifiedId { get; set; }

        /// <summary>
        /// Gets or sets the type of the notified (e.g., "Customer," "Role", "Group").
        /// </summary>
        public string NotifiedType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the notification type, indicating the nature of the notification.
        /// </summary>
        public int? NotificationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of notification (e.g., "Reminder," "Alert").
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the object related to the notification.
        /// </summary>
        public int? NotificationObjectId { get; set; }

        /// <summary>
        /// Gets or sets the type of the object associated with the notification (e.g., "Document," "Task").
        /// </summary>
        public string NotificationObjectType { get; set; }


    }
}
