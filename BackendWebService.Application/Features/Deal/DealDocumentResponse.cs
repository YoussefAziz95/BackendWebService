using System.ComponentModel.DataAnnotations;

namespace Application.Features.Deal
{
    public class DealDocumentResponse
    {
        public int Id { get; set; }
        [Range(1, 100)]
        public int Score { get; set; }
        public string? RichText { get; set; }

        public int DealId { get; set; }

        public int CriteriaId { get; set; }

        public int FileId { get; set; }

        public int FileFieldValidatorId { get; set; }

    }
}
