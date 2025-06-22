using System.ComponentModel.DataAnnotations;
using File = Domain.Entities.FilesSystem.File;

namespace Domain.Entities.Deals
{
    public class DealDocument : BaseEntity
    {
        [Range(1, 100)]
        public int? Score { get; set; }

        public string? Comment { get; set; }

        public int? StatusId { get; set; }
        public string? RichText { get; set; }

        public int DealId { get; set; }
        public int CriteriaId { get; set; }
        public int FileId { get; set; }
        public int FileFieldValidatorId { get; set; }

        // Navigation properties
        public Deal Deal { get; set; }
        public Criteria Criteria { get; set; }
        public File File { get; set; }
        public FileFieldValidator FileFieldValidator { get; set; }
    }
}
