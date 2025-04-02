
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Identity
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="Actor"/> entity.
    /// </summary>
    public sealed class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="Actor"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable("Actor");

        }
    }
}
