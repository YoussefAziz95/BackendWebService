
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Supplier"/> entity.
    /// </summary>
    public sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Supplier"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");

            // Configure the OrganizationId property
            builder.Property(v => v.OrganizationId)
                   .IsRequired();
        }
    }
}
