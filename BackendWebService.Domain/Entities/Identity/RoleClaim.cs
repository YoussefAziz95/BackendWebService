using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Domain;

namespace BackendWebService.Domain.Entities.User;

public class RoleClaim : IdentityRoleClaim<int>, IEntity, ITimeModification
{
    public override required int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public virtual required Role Role { get; set; }
    public override string? ClaimType { get; set; }
    public override string? ClaimValue { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdatedBy { get; set; }
    public int? OrganizationId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }
}