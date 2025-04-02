
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Administrator"/> entity.
    /// </summary>
    public sealed class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Administrator"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrator");

            // Configure the OrganizationId property
            builder.Property(a => a.OrganizationId)
                   .IsRequired();

            // Configure the Attributes property
            builder.Property(a => a.Attributes)
                   .HasMaxLength(500); // Adjust max length as needed

            // Configure the relationship with Organization
            builder.HasOne(a => a.Organization)
                   .WithMany() // Adjust if Organization has a navigation property back to Administrator
                   .HasForeignKey(a => a.OrganizationId)
                   .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
        }
    }
}
