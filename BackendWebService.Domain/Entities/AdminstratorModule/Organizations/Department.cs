using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Department")]
public class Department : BaseEntity, IEntity, ITimeModification
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } // Department name (e.g., Finance, IT, HR)

    [MaxLength(250)]
    public string? Description { get; set; } // Optional details

    public int? ParentDepartmentId { get; set; } // For hierarchical structures

    [ForeignKey(nameof(ParentDepartmentId))]
    public Department? ParentDepartment { get; set; }

    [InverseProperty(nameof(ParentDepartment))]
    public List<Department>? SubDepartments { get; set; }

    public int? OrganizationId { get; set; }

    [ForeignKey(nameof(OrganizationId))]
    public Organization? Organization { get; set; }

    public int? BranchId { get; set; } // Optional, if department belongs to a specific branch

    [ForeignKey(nameof(BranchId))]
    public Branch? Branch { get; set; }

    public string? Code { get; set; } // Optional unique code (e.g., "HR001")

    public bool IsActive { get; set; } = true;
}
