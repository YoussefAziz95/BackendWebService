
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations.Product
{
    /// <summary>
    /// Configuration for the <see cref="Category"/> entity.
    /// </summary>
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Configures the <see cref="Category"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the category entity.</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            // Configure the relationship with the parent category
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentId);
        }
    }
}
