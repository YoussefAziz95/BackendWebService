
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="MicrosoftConfig"/> entity.
    /// </summary>
    public sealed class MicrosoftConfigConfiguration : IEntityTypeConfiguration<MicrosoftConfig>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="MicrosoftConfig"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<MicrosoftConfig> builder)
        {
            builder.ToTable("MicrosoftConfig");

            // Configure the ConfigurationId property
            builder.Property(m => m.ConfigurationId)
                   .IsRequired();

            // Configure the ClientId property
            builder.Property(m => m.ClientId)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the TenantId property
            builder.Property(m => m.TenantId)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the Audience property
            builder.Property(m => m.Audience)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the Instance property
            builder.Property(m => m.Instance)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the relationship with Configuration
            builder.HasOne(m => m.Configuration)
                   .WithMany() // Adjust if Configuration has a navigation property back to MicrosoftConfig
                   .HasForeignKey(m => m.ConfigurationId)
                   .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
        }
    }
}
