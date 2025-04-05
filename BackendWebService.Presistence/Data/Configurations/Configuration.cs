using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.Data.Configurations;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(ur => ur.Role).WithMany().HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.NoAction);
    }
}public sealed class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasOne(ur => ur.User).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}
public sealed class RoleClaimnConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasOne(ur => ur.Role).WithMany(u => u.RoleClaim).HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.NoAction);
    }
}
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.NoAction);
    }
}
public sealed class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasKey(x => new { x.UserId, x.GroupId });
        builder.HasOne(u => u.User).WithMany().HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(g => g.Group).WithMany(g => g.UserGroups).HasForeignKey(g => g.GroupId).OnDelete(DeleteBehavior.NoAction);
    }
}
public sealed class EmailConfiguration : IEntityTypeConfiguration<EmailLog>
{
    public void Configure(EntityTypeBuilder<EmailLog> builder)
    {
        builder.HasOne(e => e.Sender).WithMany().HasForeignKey(e => e.SenderId).OnDelete(DeleteBehavior.NoAction);
    }
}
public sealed class CutomerProprtyConfiguration : IEntityTypeConfiguration<CustomerProperty>
{
    public void Configure(EntityTypeBuilder<CustomerProperty> builder)
    {
        builder.HasKey(x => new { x.CustomerId, x.PropertyId });
        builder.HasOne(x => x.Customer).WithMany(y=> y.CustomerProperties).HasForeignKey(u => u.CustomerId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Property).WithMany().HasForeignKey(g => g.PropertyId).OnDelete(DeleteBehavior.NoAction);
    }
}

