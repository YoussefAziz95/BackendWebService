
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configuration for the Group entity in the database context.
    /// </summary>
    public sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        /// <summary>
        /// Configures the Group entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");
        }
    }
}
