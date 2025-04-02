
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configurations.EmailSystem
{
    /// <summary>
    /// Configuration for the <see cref="Recipient"/> entity.
    /// </summary>
    public class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        /// <summary>
        /// Configures the <see cref="Recipient"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the recipient entity.</param>
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            // Configure the table name
            builder.ToTable("Recipient");

            // Configure the primary key
            builder.HasKey(r => r.Id);

            // Configure the relationship with the Actor (Receiver)
            builder.HasOne(r => r.Reciver)
                .WithMany() // No navigation property for Recipients in Actor
                .HasForeignKey(r => r.ReciverId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Receiver if it's referenced by a Recipient

            // Configure the relationship with the EmailDto entity
            builder.HasOne(r => r.Email)
                .WithMany() // No navigation property for Recipients in EmailDto
                .HasForeignKey(r => r.EmailId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting an EmailDto cascades to its Recipients
        }
    }
}
