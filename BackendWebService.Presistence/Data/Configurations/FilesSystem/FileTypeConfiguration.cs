
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="FileType"/> entity.
    /// </summary>
    public sealed class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="WorkflowType"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.ToTable("FileType");
        }
    }
}
