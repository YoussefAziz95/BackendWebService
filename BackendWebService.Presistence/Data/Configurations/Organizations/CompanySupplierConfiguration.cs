
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Oraganization"/> entity.
    /// </summary>
    public sealed class SupplierAccountConfiguration : IEntityTypeConfiguration<SupplierAccount>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Oraganization"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<SupplierAccount> builder)
        {
            builder.ToTable("SupplierAccount");


            // Configure the ApprovedDate property
            builder.Property(cv => cv.ApprovedDate)
                   .IsRequired(false); // Nullable

            // Configure the IsApproved property
            builder.Property(cv => cv.IsApproved)
                   .IsRequired();



            // Configure the relationship with SupplierDocuments
            builder.HasMany(cv => cv.SupplierDocuments)
                   .WithOne(cv => cv.SupplierAccount) // Adjust if SupplierDocument has a navigation property back to SupplierAccount
                   .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
        }
    }
}
