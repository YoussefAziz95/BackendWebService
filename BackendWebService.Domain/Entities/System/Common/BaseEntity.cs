using System.Diagnostics.CodeAnalysis;
public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
    public override bool Equals(object obj)
    {
        if (!(obj is BaseEntity<TKey> other))
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (GetType() != other.GetType())
            return false;
        return Id.Equals(other.Id);
    }
    public static bool operator ==(BaseEntity<TKey> a, BaseEntity<TKey> b)
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }
    public static bool operator !=(BaseEntity<TKey> a, BaseEntity<TKey> b)
    {
        return !(a == b);
    }
    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}
public interface IEntity
{
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsSystem { get; set; }
}
public interface ITimeModification
{
    DateTime? CreatedDate { get; set; }
    string? CreatedBy { get; set; }
    DateTime? UpdateDate { get; set; }
    string? UpdatedBy { get; set; }
}
public abstract class BaseEntity : BaseEntity<int>, IEntity, ITimeModification
{
    [AllowNull]
    public int? OrganizationId { get; set; }
    public bool? IsActive { get; set; } = true;
    public bool? IsDeleted { get; set; } = false;
    public bool? IsSystem { get; set; } = false;
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
}