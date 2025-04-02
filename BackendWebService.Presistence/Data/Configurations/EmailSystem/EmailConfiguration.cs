
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.EmailSystem
{
    /// <summary>
    /// Configuration for the <see cref="EmailLog"/> entity.
    /// </summary>
    public class EmailConfiguration : IEntityTypeConfiguration<EmailLog>
    {
        /// <summary>
        /// Configures the <see cref="EmailLog"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the email entity.</param>
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            // Configure the table name
            builder.ToTable("EmailDto");

            // Configure the primary key
            builder.HasKey(e => e.Id);

            // Configure the Subject property
            builder.Property(e => e.Subject)
                .IsRequired() // Subject is required
                .HasMaxLength(250); // Maximum length of 250 characters

            // Configure the Body property
            builder.Property(e => e.Body)
                .IsRequired(); // Body is required

            // Configure the SentAt property
            builder.Property(e => e.SentAt)
                .IsRequired(); // SentAt is required

            // Configure the relationship with the ApplicationUser (Sender)
            builder.HasOne(e => e.Sender)
                .WithMany() // No navigation property for Emails in ApplicationUser
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Sender if it's referenced by an EmailDto
        }
    }
}
