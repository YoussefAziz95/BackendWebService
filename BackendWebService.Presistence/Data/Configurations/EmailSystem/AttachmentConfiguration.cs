using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configurations.EmailSystem
{
    /// <summary>
    /// Configuration for the <see cref="Attachment"/> entity.
    /// </summary>
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        /// <summary>
        /// Configures the <see cref="Attachment"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the attachment entity.</param>
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            // Configure the table name
            builder.ToTable("Attachment");

            // Configure the primary key
            builder.HasKey(a => a.Id);

            // Configure the relationship with the EmailDto entity
            builder.HasOne(a => a.Email)
                .WithMany() // No navigation property for Attachments in EmailDto
                .HasForeignKey(a => a.EmailId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting an EmailDto cascades to its Attachments

            // Configure the relationship with the FileLog entity
            builder.HasOne(a => a.File)
                .WithMany() // No navigation property for Attachments in FileLog
                .HasForeignKey(a => a.FileId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a FileLog cascades to its Attachments

            // Configure the relationship with the FileFieldValidator entity
            builder.HasOne(a => a.FileFieldValidator)
                .WithMany() // No navigation property for Attachments in FileFieldValidator
                .HasForeignKey(a => a.FileFieldValidatorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of FileFieldValidator if it's referenced by an Attachment
        }
    }
}
