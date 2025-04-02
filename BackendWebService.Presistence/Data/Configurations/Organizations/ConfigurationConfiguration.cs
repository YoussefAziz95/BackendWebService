
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Configuration"/> entity.
    /// </summary>
    public sealed class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Configuration"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("Configuration");

            // Configure the ConfigurationTypeId property
            builder.Property(c => c.ConfigurationTypeId)
                   .IsRequired();

            // Configure the OrganizationId property
            builder.Property(c => c.OrganizationId)
                   .IsRequired();


            // You can configure additional properties or relationships as needed
        }
    }
}
