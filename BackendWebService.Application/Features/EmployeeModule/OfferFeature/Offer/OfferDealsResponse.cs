namespace Application.Features;
public class OfferDealsResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public List<CriteriaResponse> Criterias { get; set; }

    public List<OfferDealerResponse> offerDealderResponses { get; set; }

}
