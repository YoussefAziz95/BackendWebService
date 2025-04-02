
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Oraganization"/> entity.
    /// </summary>
    public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Oraganization"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            // Configure the OrganizationId property
            builder.Property(v => v.OrganizationId)
                   .IsRequired();

            builder.HasOne(v => v.Organization).WithOne();
        }
    }
}
