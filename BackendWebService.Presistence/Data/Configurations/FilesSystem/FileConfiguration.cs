using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="FileLog"/> entity.
    /// </summary>
    public sealed class FileConfiguration : IEntityTypeConfiguration<FileLog>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="FileLog"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<FileLog> builder)
        {
            builder.ToTable("FileLog");
        }
    }
}
