
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Organization"/> entity.
    /// </summary>
    public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Organization"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");
            // Configure the FaxNo property
            builder.Property(o => o.FaxNo)
                   .HasMaxLength(50); // Adjust max length as needed

            // Configure the Phone property
            builder.Property(o => o.Phone)
                   .HasMaxLength(50); // Adjust max length as needed

            // Configure the EmailDto property
            builder.Property(o => o.Email)
                   .IsRequired()
                   .HasMaxLength(100); // Adjust max length as needed

            // Configure the ImageLogoURL property
            builder.Property(o => o.ImageUrl)
                   .HasMaxLength(250); // Adjust max length as needed
        }
    }
}
