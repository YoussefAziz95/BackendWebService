
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="UserGroup"/> entity.
    /// </summary>
    public sealed class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="UserGroup"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroup");

            builder.HasKey(x => new { x.UserId, x.GroupId });

            builder.HasOne(u => u.User)
                 .WithMany()
                 .HasForeignKey(u => u.UserId);

            builder.HasOne(g => g.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(g => g.GroupId);
        }
    }
}
