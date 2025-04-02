
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Role"/> entity.
    /// </summary>
    public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Role"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            

        }
    }
}
