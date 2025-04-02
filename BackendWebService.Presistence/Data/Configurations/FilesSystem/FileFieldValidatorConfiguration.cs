
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="FileFieldValidator"/> entity.
    /// </summary>
    public sealed class FileFieldValidatorConfiguration : IEntityTypeConfiguration<FileFieldValidator>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="FileFieldValidator"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<FileFieldValidator> builder)
        {
            builder.ToTable("FileFieldValidator");
        }
    }
}
