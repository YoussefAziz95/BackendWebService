
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="LDAPConfig"/> entity.
    /// </summary>
    public sealed class LDAPConfigConfiguration : IEntityTypeConfiguration<LDAPConfig>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="LDAPConfig"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<LDAPConfig> builder)
        {
            builder.ToTable("LDAPConfig");

            // Configure the ConfigurationId property
            builder.Property(l => l.ConfigurationId)
                   .IsRequired();

            // Configure the ServerAddress property
            builder.Property(l => l.ServerAddress)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the CN property
            builder.Property(l => l.CN)
                   .IsRequired()
                   .HasMaxLength(100); // Adjust max length as needed

            // Configure the DC property
            builder.Property(l => l.DC)
                   .IsRequired()
                   .HasMaxLength(100); // Adjust max length as needed

            // Configure the relationship with Configuration
            builder.HasOne(l => l.Configuration)
                   .WithMany() // Adjust if Configuration has a navigation property back to LDAPConfig
                   .HasForeignKey(l => l.ConfigurationId)
                   .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
        }
    }
}
