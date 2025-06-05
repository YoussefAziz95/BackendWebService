namespace Application.Features.Deal
{
    public class UpdateDealDocumentRequest
    {

        public int Id { get; set; }
        public int CriteriaId { get; set; }

        public int FileId { get; set; }
        public string? RichText { get; set; }



    }
}
