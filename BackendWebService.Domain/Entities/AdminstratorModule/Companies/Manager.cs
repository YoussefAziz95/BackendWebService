﻿using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Managers")]
public class Manager : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public new int OrganizationId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    [NotMapped]
    public RoleEnum? ManagerType => Enum.TryParse<RoleEnum>(Position, out var parsedType) ? parsedType : null;

    [Required]
    public string Position { get; set; }
}