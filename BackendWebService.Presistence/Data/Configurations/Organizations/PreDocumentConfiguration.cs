using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configurations.Organizations
{
    /// <summary>
    /// Configures the entity framework mappings for the <see cref="PreDocument"/> entity.
    /// </summary>
    public sealed class PreDocumentConfiguration : IEntityTypeConfiguration<PreDocument>
    {
        /// <summary>
        /// Configures the entity framework mappings for the <see cref="PreDocument"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<PreDocument> builder)
        {
            builder.ToTable("PreDocument");

            builder.ToTable(tb => tb.HasTrigger("tr_DocType_ForInsert"));

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.IsRequired)
                   .HasDefaultValue(null);

            builder.Property(t => t.IsMultiple)
                   .HasDefaultValue(null);

            builder.Property(t => t.IsLocal)
                   .HasDefaultValue(null);
        }
    }
}
