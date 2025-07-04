﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Product")]
public class Product : BaseEntity, IEntity, ITimeModification
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string PartNumber { get; set; }
    public string Manufacturer { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public int? FileId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [ForeignKey(nameof(FileId))]
    public FileLog? File { get; set; }
}
