
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Google"/> entity.
    /// </summary>
    public sealed class GoogleConfiguration : IEntityTypeConfiguration<GoogleConfig>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Google"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<GoogleConfig> builder)
        {
            builder.ToTable("Google");

            // Configure the ConfigurationId property
            builder.Property(g => g.ConfigurationId)
                   .IsRequired();

            // Configure the ClientId property
            builder.Property(g => g.ClientId)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the ClientSecret property
            builder.Property(g => g.ClientSecret)
                   .IsRequired()
                   .HasMaxLength(200); // Adjust max length as needed

            // Configure the relationship with Configuration
            builder.HasOne(g => g.Configuration)
                   .WithMany() // Adjust if Configuration has a navigation property back to Google
                   .HasForeignKey(g => g.ConfigurationId)
                   .OnDelete(DeleteBehavior.Cascade); // Specify delete behavior
        }
    }
}
