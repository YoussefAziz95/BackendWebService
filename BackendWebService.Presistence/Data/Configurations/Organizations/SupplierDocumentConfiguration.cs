using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configurations.Organizations
{
    /// <summary>
    /// Configuration for the <see cref="SupplierDocument"/> entity.
    /// </summary>
    public sealed class SupplierDocumentConfiguration : IEntityTypeConfiguration<SupplierDocument>
    {
        /// <summary>
        /// Configures the <see cref="SupplierDocument"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the supplier document entity.</param>
        public void Configure(EntityTypeBuilder<SupplierDocument> builder)
        {
            builder.ToTable("SupplierDocument");

            // Set default value for IsApproved property
            builder.Property(c => c.IsApproved)
                   .HasDefaultValue(false);


            // Configure the relationship with the pre document entity
            builder.HasOne(c => c.PreDocument)
                   .WithMany()
                   .HasForeignKey(c => c.PreDocumentId);

            builder.HasOne(c => c.SupplierAccount)
                .WithMany(cv=> cv.SupplierDocuments)
                .HasForeignKey(vd=> vd.SupplierAccountId);
                
        }
    }
}
