using Application.Features.Common;
using BackendWebService.Application.Features.Criteria;
using BackendWebService.Application.Features.Deal;

namespace BackendWebService.Application.Features
{
    public class OfferDealsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<CriteriaResponse> Criterias { get; set; }

        public List<OfferDealerResponse> offerDealderResponses { get; set; }

    }
}