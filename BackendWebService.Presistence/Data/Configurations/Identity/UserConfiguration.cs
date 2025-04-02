

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configuration for the ApplicationUser entity in the database context.
    /// </summary>
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the ApplicationUser entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.IsDefaultPassword)
                .HasDefaultValue(false);


            builder.HasOne(c => c.Organization)
                    .WithMany()
                    .HasForeignKey(c => c.OrganizationId);

            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(u => u.UserId);

        }
    }
}
