
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Notifications
{
    /// <summary>
    /// Configuration for the <see cref="Notification"/> entity.
    /// </summary>
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        /// <summary>
        /// Configures the <see cref="Notification"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the notification entity.</param>
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Configure the table name
            builder.ToTable("Notification");

            // Configure the primary key
            builder.HasKey(n => n.Id);

            // Configure the KeyMessageTitle property
            builder.Property(n => n.KeyMessageTitle)
                .HasMaxLength(250); // Maximum length of 250 characters

            // Configure the KeyMessageBody property
            builder.Property(n => n.KeyMessageBody)
                .HasMaxLength(1000); // Maximum length of 1000 characters

            // Configure the Priority property
            builder.Property(n => n.Priority)
                .IsRequired() // Priority is required
                .HasMaxLength(50); // Maximum length of 50 characters

            // Configure the TimeStamp property
            builder.Property(n => n.TimeStamp)
                .IsRequired(); // TimeStamp is required

            // Configure the ExpiryDate property
            builder.Property(n => n.ExpiryDate)
                .IsRequired(); // ExpiryDate is required

            // Configure the relationship with NotificationType
            builder.Property(n => n.NotificationType)
                .HasMaxLength(100); // Assuming a max length if needed

            // Configure the relationship with NotificationObjectType
            builder.Property(n => n.NotificationObjectType)
                .HasMaxLength(100); // Assuming a max length if needed
        }
    }
}
