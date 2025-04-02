

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configuration for the ApplicationUserRole entity in the database context.
    /// </summary>
    public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Configures the ApplicationUserRole entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(ur => ur.User)
                    .WithMany(u=> u.UserRoles)
                    .HasForeignKey(c => c.UserId);    

            builder.HasOne(ur => ur.Role)
                    .WithMany(r=> r.UserRoles)
                    .HasForeignKey(c => c.RoleId);

        }
    }
}
