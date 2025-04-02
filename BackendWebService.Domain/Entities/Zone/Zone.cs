
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Zone
{
    public class Zone : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }  // Name of the zone

        public string? Description { get; set; } // Optional description of the zone

        public int? ParentZoneId { get; set; } // Nullable FK for hierarchical zones

        public Zone? ParentZone { get; set; } // Self-referencing relationship

        public ICollection<Zone>? SubZones { get; set; } // Child zones under this zone
    }
}
