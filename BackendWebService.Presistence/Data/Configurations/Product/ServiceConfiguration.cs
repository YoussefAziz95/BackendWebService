
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Product
{
    /// <summary>
    /// Configuration for the <see cref="Service"/> entity.
    /// </summary>
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        /// <summary>
        /// Configures the <see cref="Service"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the NotificationType entity.</param>
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // Configure the table name
            builder.ToTable("Service");
        }
    }
}
