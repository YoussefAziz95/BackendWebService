
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Notifications
{
    /// <summary>
    /// Configuration for the <see cref="NotificationDetail"/> entity.
    /// </summary>
    public class NotificationDetailConfiguration : IEntityTypeConfiguration<NotificationDetail>
    {
        /// <summary>
        /// Configures the <see cref="NotificationDetail"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the notification details entity.</param>
        public void Configure(EntityTypeBuilder<NotificationDetail> builder)
        {
            // Configure the table name
            builder.ToTable("NotificationDetail");

            // Configure the primary key
            builder.HasKey(nd => nd.Id);

            // Configure the NotificationId property
            builder.Property(nd => nd.NotificationId)
                .IsRequired();

            // Configure the Channel property
            builder.Property(nd => nd.Channel)
                .IsRequired()
                .HasMaxLength(100); // Assuming a maximum length of 100 for Channel


            // Configure the IsRead property
            builder.Property(nd => nd.IsRead)
                .IsRequired();

            // Configure the relationship with the Notification entity
            builder.HasOne(nd => nd.Notification)
                .WithMany() // Assuming Notification has no navigation property for NotificationDetail
                .HasForeignKey(nd => nd.NotificationId)
                .OnDelete(DeleteBehavior.Cascade); // Delete NotificationDetail when the related Notification is deleted
        }
    }
}
