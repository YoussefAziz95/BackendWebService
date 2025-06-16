using Application.Features.Common;
using Domain.Enums;


namespace Application.Features
{
    public class OfferResponse
    {
        public int Id { get; set; }
        public string? KeyName { get; set; }

        public string Name { get; set; }

        public string? KeyDescription { get; set; }

        public string Description { get; set; }

        public string? Extention { get; set; }

        public int OffererId { get; set; }

        public string Code { get; set; }

        public int? CompanyId { get; set; }

        public int? StatusId { get; set; }


        public int SpecificationsFileId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public CurrencyEnum Currency { get; set; }
        public AccessEnum AccessType { get; set; }


        public List<CriteriaResponse> Criterias { get; set; }

        public List<OfferItemResponse> OfferItems { get; set; }

        public List<OfferObjectResponse> OfferObjects { get; set; }
    }
}